namespace UsWeatherNow;

public partial class FormMain : Form
{
  public FormMain()
  {
    InitializeComponent();

    mapControl.MinZoom = 3;
    mapControl.MaxZoom = 12;
    mapControl.CenterView(39.5, -98.35, 4); // center of the contiguous US
    mapControl.GetTileClouds().Visible = checkBoxShowClouds.Checked;

    mapControl.StatusChanged += MapControl_StatusChanged;
    mapControl.ZoomLevelChanged += MapControl_ZoomLevelChanged;

    labelZoomLevel.Text = $"Zoom level: {mapControl.Zoom}";
    labelRefreshedAt.Text = $"Refreshed at {DateTime.Now.ToString("T")}";
  }

  void CheckBoxShowClouds_CheckedChanged(object sender, EventArgs e)
  {
    mapControl.GetTileClouds().Visible = checkBoxShowClouds.Checked;
    mapControl.Invalidate();
  }

  void TrackBarOpacityClouds_Scroll(object sender, EventArgs e)
  {
    mapControl.GetTileClouds().Opacity = trackBarOpacityClouds.Value / 100f;
    mapControl.Invalidate();
  }

  void CheckBoxShowRain_CheckedChanged(object sender, EventArgs e)
  {
    mapControl.GetTileRain().Visible = checkBoxShowRain.Checked;
    mapControl.Invalidate();
  }

  void TrackBarOpacityRain_Scroll(object sender, EventArgs e)
  {
    mapControl.GetTileRain().Opacity = trackBarOpacityRain.Value / 100f;
    mapControl.Invalidate();
  }

  void ButtonRefresh_Click(object sender, EventArgs e)
  {
    RefreshOverlays();
  }

  void TimerAutoRefresh_Tick(object sender, EventArgs e)
  {
    RefreshOverlays();
  }

  void MapControl_StatusChanged(string status)
  {
    labelStatusMessage.Text = status;
  }

  void MapControl_ZoomLevelChanged(int zoomLevel)
  {
    labelZoomLevel.Text = $"Zoom level: {zoomLevel}";
  }

  void RefreshOverlays()
  {
    mapControl.RefreshOverlays();
    labelRefreshedAt.Text = $"Refreshed at {DateTime.Now.ToString("T")}";
  }
}
