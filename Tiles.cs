namespace UsWeatherNow;

/// <summary>
/// The Tile class and its derived classes represent a single tile in a tile-based map system, such as OpenStreetMap or NOAA weather overlays. 
/// All Tile coordinates are in EPSG:3857 (Web Mercator) format. Coordinates are expressed in meters, with the origin (0,0) corresponding to
/// latitude=0° and longitude= 0°.
/// In Web Mercator coordinates, the X-axis increases to the right (east) and the Y-axis increases upward (north).
/// Both axes run from −20,038 to +20,038 km, which corresponds to the circumference of the Earth at the equator. 
///
/// TLDR:
///   EPSG (European Petroleum Survey Group) is a defunct organization that originally defined a set of standard coordinate reference systems for 
///   geospatial data. EPSG published a series of standards, one of which became known as EPSG:3857.
///   EPSG:3857 is a coordinate reference system used for web mapping applications. It allows for efficient tile-based rendering of maps, 
///   based on the Mercator projection. EPSG:3857 is widely used by popular mapping services like Google Maps, OpenStreetMap, and Bing Maps.
///   
///   Note: EPSG:3857 is not a true representation of the Earth's surface. Being a Mercator projection, 3857 distorts areas and distances,
///   especially near the poles. Still, it is often used for web mapping due to its simplicity and compatibility with populartile-based systems.
/// </summary>
public class Tile
{
  const double MaxTileCoordinateValue = 20_037_508.342789244; // half the earth circumference at the equator (in meters)

  public string Name { get; set; } = string.Empty;
  public bool Visible { get; set; } = true;
  public float Opacity { get; set; } = 1f;
  public int Version { get; set; }

  /// <summary>returns bounding box (in meters) of a tile in EPSG:3857 (Web Mercator) format.</summary>
  protected (double MinX, double MinY, double MaxX, double MaxY) GetTileBounds(int zoom, int x, int y)
  {
    double size = 2 * MaxTileCoordinateValue / (1 << zoom);  // size of each side of a tile in meters at the given zoom level
    double minX = -MaxTileCoordinateValue + x * size;        // left edge of the tile in meters
    double maxY = MaxTileCoordinateValue - y * size;         // top edge of the tile in meters
    return (minX, maxY - size, minX + size, maxY);
  }

  protected string F(double v) => v.ToString("0.######", System.Globalization.CultureInfo.InvariantCulture);

  // the URI where the tile can be fetched from the server, given the zoom level and tile coordinates (x, y)
  public virtual string GetUri(int zoom, int x, int y, int version = 0) { return ""; }
}

/// <summary>OpenStreetMap standard tile.</summary>
public class TileMap : Tile
{
  const string EndPoint = "https://tile.openstreetmap.org";
  
  public TileMap()
  {
    Name = "OpenStreetMap";
  }

  public override string GetUri(int z, int x, int y, int version = 0)
  {
    return $"{EndPoint}/{z}/{x}/{y}.png";
  }
}

/// <summary>OGC WMS (Open Geospatial Consortium Web Map Service) 1.3.0 tile in EPSG:3857 (Web Mercator) format.</summary>
public class TileClouds : Tile
{
  const string EndPoint = "https://nowcoast.noaa.gov/geoserver/satellite/wms";
  const string Layer = "global_longwave_imagery_mosaic";

  public TileClouds(float opacity)
  {
    Name = "NOAA Clouds (GOES IR)";
    Opacity = opacity;
  }

  public override string GetUri(int zoom, int x, int y, int version = 0)
  {
    var bounds = GetTileBounds(zoom, x, y);
    return $"{EndPoint}?SERVICE=WMS&VERSION=1.3.0&REQUEST=GetMap&LAYERS={Layer}&STYLES=" +
             $"&CRS=EPSG:3857&BBOX={F(bounds.MinX)},{F(bounds.MinY)},{F(bounds.MaxX)},{F(bounds.MaxY)}" +
             $"&WIDTH=256&HEIGHT=256&FORMAT=image/png&TRANSPARENT=TRUE&_={version}";
  }
}

/// <summary>ArcGIS Radar tile in EPSG:3857 (Web Mercator) format.</summary>
public class TileRain : Tile
{
  const string EndPoint = "https://mapservices.weather.noaa.gov/eventdriven/rest/services/radar/radar_base_reflectivity/MapServer";
  public TileRain(float opacity)
  {
    Name = "NOAA Radar";
    Opacity = opacity;
  }

  public override string GetUri(int zoom, int x, int y, int version = 0)
  {
    var bounds = GetTileBounds(zoom, x, y);
    string l = "";
    return $"{EndPoint}/export?bbox={F(bounds.MinX)},{F(bounds.MinY)},{F(bounds.MaxX)},{F(bounds.MaxY)}" +
           $"&bboxSR=3857&imageSR=3857&size=256,256&format=png32&transparent=true{l}&f=image&_={version}";
  }
}

