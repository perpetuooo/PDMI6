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
                        LatitudeLabel.Text = "Não foi possível obter a localização.";
                        LongitudeLabel.Text = "Verifique as permissões do dispositivo.";
                    }
                }
                else
                {
                    LatitudeLabel.Text = "Permissão negada.";
                    LongitudeLabel.Text = "Habilite o acesso à localização nas configurações.";
                }
            }
            catch (Exception ex)
            {
                LatitudeLabel.Text = $"Erro: {ex.Message}";
                LongitudeLabel.Text = "Verifique se a localização está ativada.";
            }
        }
    }
}
