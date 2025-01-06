using Microsoft.Maui.Devices.Sensors;

namespace P2
{
    public partial class LocationPage : ContentPage
    {
        public LocationPage()
        {
            InitializeComponent();
        }

        private async void OnGetLocationClicked(object sender, EventArgs e)
        {
            try
            {
                var status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();

                if (status == PermissionStatus.Granted)
                {
                    var location = await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Best));

                    if (location != null)
                    {
                        LatitudeLabel.Text = $"Latitude: {location.Latitude}";
                        LongitudeLabel.Text = $"Longitude: {location.Longitude}";
                    }
                    else
                    {
                        LatitudeLabel.Text = "N�o foi poss�vel obter a localiza��o.";
                        LongitudeLabel.Text = "Verifique as permiss�es do dispositivo.";
                    }
                }
                else
                {
                    LatitudeLabel.Text = "Permiss�o negada.";
                    LongitudeLabel.Text = "Habilite o acesso � localiza��o nas configura��es.";
                }
            }
            catch (Exception ex)
            {
                LatitudeLabel.Text = $"Erro: {ex.Message}";
                LongitudeLabel.Text = "Verifique se a localiza��o est� ativada.";
            }
        }
    }
}
