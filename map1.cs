using System;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        // Create and add GMapControl to the form
        GMapControl gMapControl1 = new GMapControl();
        gMapControl1.Dock = DockStyle.Fill;
        this.Controls.Add(gMapControl1);

        // Set GMapControl properties when the form loads
        this.Load += (s, e) =>
        {
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            gMapControl1.Position = new PointLatLng(37.7749, -122.4194); // San Francisco
            gMapControl1.MinZoom = 1;
            gMapControl1.MaxZoom = 18;
            gMapControl1.Zoom = 13;

            // Create marker overlay
            GMapOverlay markersOverlay = new GMapOverlay("markers");
            GMapMarker marker = new GMarkerGoogle(
                new PointLatLng(37.7749, -122.4194),
                GMarkerGoogleType.red);
            marker.ToolTipText = "San Francisco";
            markersOverlay.Markers.Add(marker);

            // Add overlay to map
            gMapControl1.Overlays.Add(markersOverlay);
        };
    }
}
