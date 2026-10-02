using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace UsWeatherNow;

partial class FormMain
{
  /// <summary>
  ///  Required designer variable.
  /// </summary>
  private System.ComponentModel.IContainer components = null;

  /// <summary>
  ///  Clean up any resources being used.
  /// </summary>
  /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
  protected override void Dispose(bool disposing)
  {
    if (disposing && (components != null))
    {
      components.Dispose();
    }
    base.Dispose(disposing);
  }

  #region Windows Form Designer generated code

  /// <summary>
  ///  Required method for Designer support - do not modify
  ///  the contents of this method with the code editor.
  /// </summary>
  private void InitializeComponent()
  {
    components = new System.ComponentModel.Container();
    panelTop = new Panel();
    buttonRefresh = new Button();
    groupBox2 = new GroupBox();
    trackBarOpacityRain = new TrackBar();
    label2 = new Label();
    checkBoxShowRain = new CheckBox();
    groupBox1 = new GroupBox();
    trackBarOpacityClouds = new TrackBar();
    label1 = new Label();
    checkBoxShowClouds = new CheckBox();
    panelBottom = new Panel();
    labelStatusMessage = new Label();
    labelZoomLevel = new Label();
    labelRefreshedAt = new Label();
    panelMiddle = new Panel();
    mapControl = new MapControl();
    panelColors = new Panel();
    label24 = new Label();
    label22 = new Label();
    label21 = new Label();
    label20 = new Label();
    label18 = new Label();
    label8 = new Label();
    label16 = new Label();
    label19 = new Label();
    label17 = new Label();
    label14 = new Label();
    label15 = new Label();
    label12 = new Label();
    label13 = new Label();
    label10 = new Label();
    label11 = new Label();
    label9 = new Label();
    label6 = new Label();
    label7 = new Label();
    label5 = new Label();
    label4 = new Label();
    label3 = new Label();
    timerAutoRefresh = new System.Windows.Forms.Timer(components);
    toolTip = new ToolTip(components);
    panelTop.SuspendLayout();
    groupBox2.SuspendLayout();
    ((System.ComponentModel.ISupportInitialize)trackBarOpacityRain).BeginInit();
    groupBox1.SuspendLayout();
    ((System.ComponentModel.ISupportInitialize)trackBarOpacityClouds).BeginInit();
    panelBottom.SuspendLayout();
    panelMiddle.SuspendLayout();
    panelColors.SuspendLayout();
    SuspendLayout();
    // 
    // panelTop
    // 
    panelTop.Controls.Add(buttonRefresh);
    panelTop.Controls.Add(groupBox2);
    panelTop.Controls.Add(groupBox1);
    panelTop.Dock = DockStyle.Top;
    panelTop.Location = new Point(0, 0);
    panelTop.Name = "panelTop";
    panelTop.Size = new Size(990, 89);
    panelTop.TabIndex = 0;
    // 
    // buttonRefresh
    // 
    buttonRefresh.Location = new Point(609, 36);
    buttonRefresh.Name = "buttonRefresh";
    buttonRefresh.Size = new Size(75, 23);
    buttonRefresh.TabIndex = 7;
    buttonRefresh.Text = "Refresh";
    toolTip.SetToolTip(buttonRefresh, "Refresh clouds/rain now");
    buttonRefresh.UseVisualStyleBackColor = true;
    buttonRefresh.Click += ButtonRefresh_Click;
    // 
    // groupBox2
    // 
    groupBox2.Controls.Add(trackBarOpacityRain);
    groupBox2.Controls.Add(label2);
    groupBox2.Controls.Add(checkBoxShowRain);
    groupBox2.Location = new Point(305, 12);
    groupBox2.Name = "groupBox2";
    groupBox2.Size = new Size(257, 62);
    groupBox2.TabIndex = 6;
    groupBox2.TabStop = false;
    groupBox2.Text = "Rain";
    // 
    // trackBarOpacityRain
    // 
    trackBarOpacityRain.Location = new Point(144, 22);
    trackBarOpacityRain.Maximum = 100;
    trackBarOpacityRain.Minimum = 10;
    trackBarOpacityRain.Name = "trackBarOpacityRain";
    trackBarOpacityRain.Size = new Size(104, 45);
    trackBarOpacityRain.TabIndex = 2;
    trackBarOpacityRain.TickStyle = TickStyle.None;
    toolTip.SetToolTip(trackBarOpacityRain, "How transparent/opaque rain is");
    trackBarOpacityRain.Value = 75;
    trackBarOpacityRain.Scroll += TrackBarOpacityRain_Scroll;
    // 
    // label2
    // 
    label2.AutoSize = true;
    label2.Location = new Point(98, 26);
    label2.Name = "label2";
    label2.Size = new Size(48, 15);
    label2.TabIndex = 4;
    label2.Text = "Opacity";
    // 
    // checkBoxShowRain
    // 
    checkBoxShowRain.AutoSize = true;
    checkBoxShowRain.CheckAlign = ContentAlignment.MiddleRight;
    checkBoxShowRain.Checked = true;
    checkBoxShowRain.CheckState = CheckState.Checked;
    checkBoxShowRain.Location = new Point(16, 25);
    checkBoxShowRain.Name = "checkBoxShowRain";
    checkBoxShowRain.Size = new Size(55, 19);
    checkBoxShowRain.TabIndex = 0;
    checkBoxShowRain.Text = "Show";
    toolTip.SetToolTip(checkBoxShowRain, "Show/hide rain");
    checkBoxShowRain.UseVisualStyleBackColor = true;
    checkBoxShowRain.CheckedChanged += CheckBoxShowRain_CheckedChanged;
    // 
    // groupBox1
    // 
    groupBox1.Controls.Add(trackBarOpacityClouds);
    groupBox1.Controls.Add(label1);
    groupBox1.Controls.Add(checkBoxShowClouds);
    groupBox1.Location = new Point(27, 12);
    groupBox1.Name = "groupBox1";
    groupBox1.Size = new Size(257, 62);
    groupBox1.TabIndex = 5;
    groupBox1.TabStop = false;
    groupBox1.Text = "Clouds";
    // 
    // trackBarOpacityClouds
    // 
    trackBarOpacityClouds.Location = new Point(144, 22);
    trackBarOpacityClouds.Maximum = 100;
    trackBarOpacityClouds.Minimum = 10;
    trackBarOpacityClouds.Name = "trackBarOpacityClouds";
    trackBarOpacityClouds.Size = new Size(104, 45);
    trackBarOpacityClouds.TabIndex = 2;
    trackBarOpacityClouds.TickStyle = TickStyle.None;
    toolTip.SetToolTip(trackBarOpacityClouds, "How transparent/opaque clouds are");
    trackBarOpacityClouds.Value = 30;
    trackBarOpacityClouds.Scroll += TrackBarOpacityClouds_Scroll;
    // 
    // label1
    // 
    label1.AutoSize = true;
    label1.Location = new Point(98, 26);
    label1.Name = "label1";
    label1.Size = new Size(48, 15);
    label1.TabIndex = 4;
    label1.Text = "Opacity";
    // 
    // checkBoxShowClouds
    // 
    checkBoxShowClouds.AutoSize = true;
    checkBoxShowClouds.CheckAlign = ContentAlignment.MiddleRight;
    checkBoxShowClouds.Location = new Point(16, 25);
    checkBoxShowClouds.Name = "checkBoxShowClouds";
    checkBoxShowClouds.Size = new Size(55, 19);
    checkBoxShowClouds.TabIndex = 0;
    checkBoxShowClouds.Text = "Show";
    toolTip.SetToolTip(checkBoxShowClouds, "Show/hide clouds");
    checkBoxShowClouds.UseVisualStyleBackColor = true;
    checkBoxShowClouds.CheckedChanged += CheckBoxShowClouds_CheckedChanged;
    // 
    // panelBottom
    // 
    panelBottom.BorderStyle = BorderStyle.FixedSingle;
    panelBottom.Controls.Add(labelStatusMessage);
    panelBottom.Controls.Add(labelZoomLevel);
    panelBottom.Controls.Add(labelRefreshedAt);
    panelBottom.Dock = DockStyle.Bottom;
    panelBottom.Location = new Point(0, 569);
    panelBottom.Name = "panelBottom";
    panelBottom.Size = new Size(990, 28);
    panelBottom.TabIndex = 1;
    // 
    // labelStatusMessage
    // 
    labelStatusMessage.Dock = DockStyle.Fill;
    labelStatusMessage.Location = new Point(0, 0);
    labelStatusMessage.Name = "labelStatusMessage";
    labelStatusMessage.Size = new Size(765, 26);
    labelStatusMessage.TabIndex = 2;
    labelStatusMessage.TextAlign = ContentAlignment.MiddleLeft;
    // 
    // labelZoomLevel
    // 
    labelZoomLevel.Dock = DockStyle.Right;
    labelZoomLevel.Location = new Point(765, 0);
    labelZoomLevel.Name = "labelZoomLevel";
    labelZoomLevel.Size = new Size(100, 26);
    labelZoomLevel.TabIndex = 1;
    labelZoomLevel.Text = "Zoom level: 5";
    labelZoomLevel.TextAlign = ContentAlignment.MiddleLeft;
    // 
    // labelRefreshedAt
    // 
    labelRefreshedAt.Dock = DockStyle.Right;
    labelRefreshedAt.Location = new Point(865, 0);
    labelRefreshedAt.Name = "labelRefreshedAt";
    labelRefreshedAt.Size = new Size(123, 26);
    labelRefreshedAt.TabIndex = 0;
    labelRefreshedAt.Text = "Refreshed at 15:38:47";
    labelRefreshedAt.TextAlign = ContentAlignment.MiddleLeft;
    // 
    // panelMiddle
    // 
    panelMiddle.Controls.Add(mapControl);
    panelMiddle.Controls.Add(panelColors);
    panelMiddle.Dock = DockStyle.Fill;
    panelMiddle.Location = new Point(0, 89);
    panelMiddle.Name = "panelMiddle";
    panelMiddle.Size = new Size(990, 480);
    panelMiddle.TabIndex = 2;
    // 
    // mapControl
    // 
    mapControl.BackColor = Color.FromArgb(170, 211, 223);
    mapControl.Dock = DockStyle.Fill;
    mapControl.Location = new Point(0, 46);
    mapControl.MaxZoom = 12;
    mapControl.MinZoom = 3;
    mapControl.Name = "mapControl";
    mapControl.Size = new Size(990, 434);
    mapControl.TabIndex = 0;
    // 
    // panelColors
    // 
    panelColors.BorderStyle = BorderStyle.FixedSingle;
    panelColors.Controls.Add(label24);
    panelColors.Controls.Add(label22);
    panelColors.Controls.Add(label21);
    panelColors.Controls.Add(label20);
    panelColors.Controls.Add(label18);
    panelColors.Controls.Add(label8);
    panelColors.Controls.Add(label16);
    panelColors.Controls.Add(label19);
    panelColors.Controls.Add(label17);
    panelColors.Controls.Add(label14);
    panelColors.Controls.Add(label15);
    panelColors.Controls.Add(label12);
    panelColors.Controls.Add(label13);
    panelColors.Controls.Add(label10);
    panelColors.Controls.Add(label11);
    panelColors.Controls.Add(label9);
    panelColors.Controls.Add(label6);
    panelColors.Controls.Add(label7);
    panelColors.Controls.Add(label5);
    panelColors.Controls.Add(label4);
    panelColors.Controls.Add(label3);
    panelColors.Dock = DockStyle.Top;
    panelColors.Location = new Point(0, 0);
    panelColors.Name = "panelColors";
    panelColors.Size = new Size(990, 46);
    panelColors.TabIndex = 1;
    // 
    // label24
    // 
    label24.BackColor = Color.White;
    label24.BorderStyle = BorderStyle.FixedSingle;
    label24.Location = new Point(850, 14);
    label24.Name = "label24";
    label24.Size = new Size(21, 21);
    label24.TabIndex = 23;
    // 
    // label22
    // 
    label22.BackColor = Color.FromArgb(150, 0, 150);
    label22.BorderStyle = BorderStyle.FixedSingle;
    label22.Location = new Point(824, 14);
    label22.Name = "label22";
    label22.Size = new Size(21, 21);
    label22.TabIndex = 21;
    // 
    // label21
    // 
    label21.BackColor = Color.Fuchsia;
    label21.BorderStyle = BorderStyle.FixedSingle;
    label21.Location = new Point(678, 14);
    label21.Name = "label21";
    label21.Size = new Size(21, 21);
    label21.TabIndex = 20;
    // 
    // label20
    // 
    label20.BackColor = Color.FromArgb(220, 0, 220);
    label20.BorderStyle = BorderStyle.FixedSingle;
    label20.Location = new Point(652, 14);
    label20.Name = "label20";
    label20.Size = new Size(21, 21);
    label20.TabIndex = 19;
    // 
    // label18
    // 
    label18.BackColor = Color.FromArgb(190, 0, 0);
    label18.BorderStyle = BorderStyle.FixedSingle;
    label18.Location = new Point(526, 14);
    label18.Name = "label18";
    label18.Size = new Size(21, 21);
    label18.TabIndex = 18;
    // 
    // label8
    // 
    label8.BackColor = Color.Red;
    label8.BorderStyle = BorderStyle.FixedSingle;
    label8.Location = new Point(474, 14);
    label8.Name = "label8";
    label8.Size = new Size(21, 21);
    label8.TabIndex = 17;
    // 
    // label16
    // 
    label16.BackColor = Color.FromArgb(255, 200, 0);
    label16.BorderStyle = BorderStyle.FixedSingle;
    label16.Location = new Point(338, 14);
    label16.Name = "label16";
    label16.Size = new Size(21, 21);
    label16.TabIndex = 16;
    // 
    // label19
    // 
    label19.BackColor = Color.Green;
    label19.BorderStyle = BorderStyle.FixedSingle;
    label19.Location = new Point(204, 14);
    label19.Name = "label19";
    label19.Size = new Size(21, 21);
    label19.TabIndex = 15;
    // 
    // label17
    // 
    label17.BackColor = Color.FromArgb(120, 157, 194);
    label17.BorderStyle = BorderStyle.FixedSingle;
    label17.Location = new Point(152, 14);
    label17.Name = "label17";
    label17.Size = new Size(21, 21);
    label17.TabIndex = 13;
    // 
    // label14
    // 
    label14.AutoSize = true;
    label14.Location = new Point(874, 17);
    label14.Name = "label14";
    label14.Size = new Size(50, 15);
    label14.TabIndex = 12;
    label14.Text = "Extreme";
    // 
    // label15
    // 
    label15.BackColor = Color.FromArgb(90, 0, 90);
    label15.BorderStyle = BorderStyle.FixedSingle;
    label15.Location = new Point(798, 14);
    label15.Name = "label15";
    label15.Size = new Size(21, 21);
    label15.TabIndex = 11;
    // 
    // label12
    // 
    label12.AutoSize = true;
    label12.Location = new Point(702, 17);
    label12.Name = "label12";
    label12.Size = new Size(63, 15);
    label12.TabIndex = 10;
    label12.Text = "Very heavy";
    // 
    // label13
    // 
    label13.BackColor = Color.FromArgb(200, 0, 200);
    label13.BorderStyle = BorderStyle.FixedSingle;
    label13.Location = new Point(626, 14);
    label13.Name = "label13";
    label13.Size = new Size(21, 21);
    label13.TabIndex = 9;
    // 
    // label10
    // 
    label10.AutoSize = true;
    label10.Location = new Point(550, 17);
    label10.Name = "label10";
    label10.Size = new Size(40, 15);
    label10.TabIndex = 8;
    label10.Text = "Heavy";
    // 
    // label11
    // 
    label11.BackColor = Color.FromArgb(220, 0, 0);
    label11.BorderStyle = BorderStyle.FixedSingle;
    label11.Location = new Point(500, 14);
    label11.Name = "label11";
    label11.Size = new Size(21, 21);
    label11.TabIndex = 7;
    // 
    // label9
    // 
    label9.BackColor = Color.FromArgb(255, 128, 0);
    label9.BorderStyle = BorderStyle.FixedSingle;
    label9.Location = new Point(364, 14);
    label9.Name = "label9";
    label9.Size = new Size(21, 21);
    label9.TabIndex = 5;
    // 
    // label6
    // 
    label6.AutoSize = true;
    label6.Location = new Point(388, 17);
    label6.Name = "label6";
    label6.Size = new Size(58, 15);
    label6.TabIndex = 4;
    label6.Text = "Moderate";
    // 
    // label7
    // 
    label7.BackColor = Color.Yellow;
    label7.BorderStyle = BorderStyle.FixedSingle;
    label7.Location = new Point(312, 14);
    label7.Name = "label7";
    label7.Size = new Size(21, 21);
    label7.TabIndex = 3;
    // 
    // label5
    // 
    label5.AutoSize = true;
    label5.Location = new Point(228, 17);
    label5.Name = "label5";
    label5.Size = new Size(34, 15);
    label5.TabIndex = 2;
    label5.Text = "Light";
    // 
    // label4
    // 
    label4.BackColor = Color.FromArgb(78, 220, 87);
    label4.BorderStyle = BorderStyle.FixedSingle;
    label4.Location = new Point(178, 14);
    label4.Name = "label4";
    label4.Size = new Size(21, 21);
    label4.TabIndex = 1;
    // 
    // label3
    // 
    label3.AutoSize = true;
    label3.Font = new System.Drawing.Font("Segoe UI", 9F, FontStyle.Bold);
    label3.ForeColor = Color.Teal;
    label3.Location = new Point(8, 17);
    label3.Name = "label3";
    label3.Size = new Size(115, 15);
    label3.TabIndex = 0;
    label3.Text = "Precipitation Colors";
    // 
    // timerAutoRefresh
    // 
    timerAutoRefresh.Enabled = true;
    timerAutoRefresh.Interval = 300000;
    timerAutoRefresh.Tick += TimerAutoRefresh_Tick;
    // 
    // FormMain
    // 
    AutoScaleDimensions = new SizeF(7F, 15F);
    AutoScaleMode = AutoScaleMode.Font;
    ClientSize = new Size(990, 597);
    Controls.Add(panelMiddle);
    Controls.Add(panelBottom);
    Controls.Add(panelTop);
    Name = "FormMain";
    Text = "US Weather Now";
    panelTop.ResumeLayout(false);
    groupBox2.ResumeLayout(false);
    groupBox2.PerformLayout();
    ((System.ComponentModel.ISupportInitialize)trackBarOpacityRain).EndInit();
    groupBox1.ResumeLayout(false);
    groupBox1.PerformLayout();
    ((System.ComponentModel.ISupportInitialize)trackBarOpacityClouds).EndInit();
    panelBottom.ResumeLayout(false);
    panelMiddle.ResumeLayout(false);
    panelColors.ResumeLayout(false);
    panelColors.PerformLayout();
    ResumeLayout(false);
  }

  #endregion

  private Panel panelTop;
  private CheckBox checkBoxShowClouds;
  private Panel panelBottom;
  private Panel panelMiddle;
  private Button buttonRefresh;
  private GroupBox groupBox2;
  private TrackBar trackBarOpacityRain;
  private Label label2;
  private CheckBox checkBoxShowRain;
  private GroupBox groupBox1;
  private TrackBar trackBarOpacityClouds;
  private Label label1;
  private Label labelStatusMessage;
  private Label labelZoomLevel;
  private Label labelRefreshedAt;
  private System.Windows.Forms.Timer timerAutoRefresh;
  private MapControl mapControl;
  private Panel panelColors;
  private Label label12;
  private Label label13;
  private Label label10;
  private Label label11;
  private Label label9;
  private Label label6;
  private Label label7;
  private Label label5;
  private Label label4;
  private Label label3;
  private Label label14;
  private Label label15;
  private Label label19;
  private Label label17;
  private Label label18;
  private Label label8;
  private Label label16;
  private Label label24;
  private Label label22;
  private Label label21;
  private Label label20;
  private ToolTip toolTip;
}
