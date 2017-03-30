using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Camara
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        private async void TomarFotografia(object sender, EventArgs e)
        {
            var opciones_almacenamiento = new StoreCameraMediaOptions()
            {
                SaveToAlbum = true,
                Name = "Foto_HRMG.jpg"
            };

            var foto = await CrossMedia.Current.TakePhotoAsync(opciones_almacenamiento);
            Foto_HRMG.Source = ImageSource.FromStream(() =>
            {
                var stream = foto.GetStream();
                foto.Dispose();
                return stream;
            });
        }

        private async void ElegirImagen(object sender, EventArgs e)
        {
            if (CrossMedia.Current.IsTakePhotoSupported)
            {
                var imagen = await CrossMedia.Current.PickPhotoAsync();
                if (imagen != null)
                {
                    Foto_HRMG.Source = ImageSource.FromStream(() =>
                    {
                        var stream = imagen.GetStream();
                        imagen.Dispose();
                        return stream;
                    });
                }
            }
        }
	}
}
