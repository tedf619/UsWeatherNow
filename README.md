# UsWeatherNow 
A simple .NET 10 WinForms app that displays a map of the current weather in the United States and adjacent areas.

## Features
* Great project for getting started with maps and online weather services.
* No dependencies on GitHub packages or third-party components.
* Shows cloud cover and rain.
* Uses free web service APIs from NOAA (National Oceanic and Atmospheric Administration).
* No API keys required.

This app shows a map of the United States with optional overlays for cloud cover and rain. The following figure shows USWeatherNow in action, with the rain overlay selected.

<img width="992" height="629" alt="image" src="https://github.com/user-attachments/assets/4b682be9-14cf-4765-a705-28f7e8cb1a48" />

*Figure 1* - The app showing where rain is present.
<br><br>

To get a better idea of the developing weather, you can turn on the cloud cover layer, as shown in the next figure.

<img width="992" height="629" alt="image" src="https://github.com/user-attachments/assets/65c094cc-56a8-4827-9663-756696b01ff7" />

*Figure 2* - The app showing both clouds and rain.

The app uses OpenStreetMap for the map. The cloud data is retrieved from NOAA's **nowcast** server at ```https://nowcoast.noaa.gov/geoserver/satellite/wms```.
The rain data is from NOAA's **mapservices** server at ```https://mapservices.weather.noaa.gov/eventdriven/rest/services/radar/radar_base_reflectivity/MapServer```.

## The UI Layout

The user interface uses two layers of docked panels for its layout, as shown in the following figure.

<img width="778" height="520" alt="image" src="https://github.com/user-attachments/assets/79b4ccf0-789b-403d-863a-d6dabb72b6f8" />

*Figure 3* - The docked panels for the user interface.

* *Layer 1* - Shown in red, this layer divides the screen vertically, with the middle area filling available space.
* *Layer 2* - Shown in blue, this layer is just for the map, which fills the middle area of layer 1.

To achieve the required layout, the panels in layer 1 must be added in the proper back-to-front order, like this:

  1. PanelTop.
  2. PanelColors.
  3. PanelBottom.
  4. PanelMiddle.

As a general rule, components with Dock=Fill must always be added last to their parent container.

## How it Works

The main form of the app is just used to setup the layout and handle user interactions with the UI controls. The interesting stuff is
mostly in MapControl. It handles the download and display of the map, the cloud overlay and the rain overlay. All three of these are made up by tiles that fit tightly together to create a complete and seamless image.
The geographic area covered by each tile depends on the Zoom level, which you can change using the mouse wheel. You can also pan the map by clicking and dragging the mouse.
<p>
The map is initialized in FormMain with the following code fragment.

```csharp
public partial class FormMain : Form
{
  public FormMain()
  {
    InitializeComponent();

    //...
    mapControl.CenterView(39.5, -98.35, 4); // center of the contiguous US
  }
}
```
*Listing 1* - Initializing the map.

The map is centered on latitude=39.5 and longitude=-98.34, with zoom=4. These values make the map show the entire continental US. FormMain contains no other interesting logic, other than handling user clicks and mouse actions, which are all delegated to MapControl. When you drag the map, MapControl downloads tiles for new areas being shown. When you zoom the map, MapControl downloads new tiles for the new zoom level. Tiles are stored in a memory cache, to obviate the need to download a given tile more than once.

## The Map

Displaying a map is more complicated than it might seem at first, because the Earth is round and we usually display maps on a flat surface. A rather naive but simple way to handle the problem is to use a Mercator projection of the Earth.
The idea is to conceptually wrap a cylinder around the Earth so that it touches the globe at the equator. Mercator maps are the projection of the Earth's surface onto that cylinder, which is then unwrapped into a flat rectangle. The following figure shows the idea as described by ChatGPT.

<img width="622" height="491" alt="image" src="https://github.com/user-attachments/assets/fac56686-6734-4c17-8964-92ee0bb79fe0" />

*Figure 4* - Generating a Mercator projection of the Earth.

Mercator projections provide reasonably good approximations of countries at lower latitudes. The farther you get from the equator, the greater the distortion. Near the poles, the distortion is huge. Look at you big Greenland and Antarctica appear on the map. What makes Mercator projections popular is their ease of use. You can simply divide the square map into smaller square tiles, avoiding a lot of tricky math to account for the round Earth.
<br><br>
The *Web Mercator* is a special format for Mercator maps. It's based on a standard called EPSG:3857, which uses 256x256 pixel tiles. The coordinate system uses longitude for the X axis and latitude for the Y axis. The origin corresponds to the point at longitude=0 and latitude=0, which is the center of the map. This point turns out to be somewhere in the Gulf of Guinea, off the coast of West Africa. The X axis increases to the right (East). The Y axis increases upward (North).
In Web Mercator, the Earth is assumed to be a perfect sphere, so the height and width of the map are the same: about 40,000 km, which is the circumference of the Earth at the equator. Since the origin is in the middle of the map, no location can be farther than about + or - 20,000 km.

## Tiles

As mentioned earlier, the Web Mercator format is based on 256x256 pixel tiles. UsWeatherNow uses tiles for three things:

  1. The map.
  2. The cloud layer.
  3. The rain layer.

The main difference between the three tiles is their name and the URI of the webservice endpoint that supplies their bitmaps. The following figure shows class hierarchy.

<img width="1084" height="388" alt="image" src="https://github.com/user-attachments/assets/d5a1f5b9-c28e-4ac3-af60-2d5a1cd07a2d" />

*Figure 5* - The Tile class hierachy.

The tile name is set in the class constructors. The GetUri method is virtual, so calling tile.GetUri will polymorphically call the GetUri method of whatever tile type you have.
The following listing shows the highlights of the Tile classes.

```csharp
public class Tile
{
  const double MaxTileCoordinateValue = 20_037_508.342789244; // half the earth circumference at the equator (in meters)

  public string Name { get; set; } = string.Empty;
  public float Opacity { get; set; } = 1f;

  public virtual string GetUri(int zoom, int x, int y, int version = 0) { return ""; }
  //...
}

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

public class TileClouds : Tile
{
  const string EndPoint = "https://nowcoast.noaa.gov/...";
  const string Layer = "global_longwave_imagery_mosaic";

  public TileClouds(float opacity)
  {
    Name = "NOAA Clouds (GOES IR)";
    Opacity = opacity;
  }

  public override string GetUri(int zoom, int x, int y, int version = 0)
  {
    var bounds = GetTileBounds(zoom, x, y);
    return $"{EndPoint}?...";  // full URI omitted here
  }
}

public class TileRain : Tile
{
  const string EndPoint = "https://mapservices.weather.noaa.gov/...";
  public TileRain(float opacity)
  {
    Name = "NOAA Radar";
    Opacity = opacity;
  }

  public override string GetUri(int zoom, int x, int y, int version = 0)
  {
    var bounds = GetTileBounds(zoom, x, y);
    return $"{EndPoint}?...";  // full URI omitted here
  }
}
```

*Listing 2* - The code highlights of the Tile classes.

## Downloading Tiles

MapControl handles the downloading of all tiles using the RequestTile method. The following listing shows the main code.

```csharp
  async void RequestTile(Tile tile, int zoom, int x, int y, string cacheKey)
  {
    // download the bytes for a tile from the server for the given tile type
    byte[] data = await http.GetByteArrayAsync(tile.GetUri(zoom, x, y, tile.Version));  // Tile.GetUri() is virtual

    // convert bytes to a bitmap representation of the tile
    using var ms = new MemoryStream(data);
    var bitmap = new Bitmap(ms);

    // save tile in the cache
    tileCache[cacheKey] = bitmap;
    tileOrderInCache.Enqueue(cacheKey);

    Invalidate();
  }
```

*Listing 3* - Downloading tiles.

The first line calls Tile.GetUri(...) to get the URI for the tile. Since this method is virtual, it returns the correct URI based on the type of Tile involved. Downloaded tiles are stored in a tile cache, which is just a 
Dictionary define like this: ```Dictionary<string, Bitmap>```. The value is the 256x256 pixel bitmap for the tile, the key is a combination of tile-specific properties put together with the following code:

```csharp
string GetCacheKey(Tile tile, int zoom, int x, int y) => $"{tile.Name}|{tile.Version}|{zoom}|{x}|{y}";
```
*Listing 4* - Generating a key for the Tile cache.

Before calling RequestTile, MapControl checks to see if the tile is already in the cache. If so, it uses the cached tile.

## Painting Tiles

Painting a map on the screen entails painting tiles. These are painted in the method MapControl.OnPaint, whose highlights are shown in the following listing.

```csharp
protected override void OnPaint(PaintEventArgs e)
{
  var g = e.Graphics;
 
  //...

  double size = WorldSize(Zoom);  // size of each side in pixels of the square Mercator world at this zoom level
  int tilesPerSide = 1 << Zoom;   // number of tiles per side of the square Mercator map at this zoom level
  double left = centerX - Width / 2.0;
  double top = centerY - Height / 2.0;

  int x0 = (int)Math.Floor(left / TileSizeInPixels);                                       // leftmost tile index (can be negative)
  int x1 = (int)Math.Floor((left + Width) / TileSizeInPixels);                             // rightmost tile index (can be greater than tilesPerSide - 1)
  int y0 = Math.Max(0, (int)Math.Floor(top / TileSizeInPixels));                           // topmost tile index (clamped to 0)
  int y1 = Math.Min(tilesPerSide - 1, (int)Math.Floor((top + Height) / TileSizeInPixels)); // bottommost tile index (clamped to tilesPerSide - 1)

  foreach (var layer in Layers.Where(l => l.Visible))
  {
    //...
    for (int ty = y0; ty <= y1; ty++)     // iterate over the visible tile rows
    {
      for (int tx = x0; tx <= x1; tx++)   // iterate over the visible tile columns
      {
        int wrappedX = ((tx % tilesPerSide) + tilesPerSide) % tilesPerSide;  // wrap X coordinate around the world map
        string key = GetCacheKey(layer, Zoom, wrappedX, ty);                 // unique key for this tile in the cache

        var destination = new Rectangle(                    // client coordinates where the tile should be drawn
            (int)Math.Round(tx * TileSizeInPixels - left),  // top-left X of the tile in client coordinates (0,0 is top-left of control)
            (int)Math.Round(ty * TileSizeInPixels - top),   // top-left Y of the tile in client coordinates
            TileSizeInPixels, TileSizeInPixels);            // width and height of the tile in client coordinates

        // if the tile is already downloaded and cached, draw it; otherwise, request it

        if (tileCache.TryGetValue(key, out var bitmap))
          g.DrawImage(bitmap, destination, 0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel, imageAttributes);

        else if (!failedTiles.Contains(key))
          RequestTile(layer, Zoom, wrappedX, ty, key);
      }
    }
  }
}
```

*Listing 5* - Painting tiles on the screen.

Tile coordinates are in meters, indicating the X and Y distance from the center of the Web Mercator map. To paint tiles, these coordinates must be converted to MapControl client coordinates. 
The line ```g.DrawImage(...)``` does the actual painting.

## Closing Notes

Much of the logic in a mapping app is devoted to coordinate management and conversions. If you don't understand the coordinate systems, you'll have a hard time modifying the code to add your own new features.
A few features that could be useful are:

1. Showing maps of areas other than the US. For the map, just change the coordinates of the map center in FormMain. That's the easy part. The harder part is getting cloud and rain data for the new geographic area. The NOAA web services in UsWeatherNow only cover the United States and adjacent areas. To get cloud and rain data for Europe and Asia you might consider RainViewer, MeteoSat or NASA GIBS (Global Imagery Browse Services on GitHub). The important thing is to only consider services that return tiles in Web Mercator format.
   <br><br>
2. Animation. Seeing a static image of clouds and rain doesn't tell you the whole picture. What is more interesting is how the weather is moving and changing. This requires animation, showing a series of frames over time up to the present. Handling animation isn't trivial, so I omitted it in this app.

Many thanks to Google Gemini and ChatGPT.
