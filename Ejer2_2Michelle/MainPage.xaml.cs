using Ejer2_2Michelle.Models;
using Ejer2_2Michelle.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ejer2_2Michelle
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnlistar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new View.Listado());
        }

        private async void btnsalvar_Clicked(object sender, EventArgs e)
        {

            if (Sign.IsBlank)
            {
                Message("Debes llenar todos los campos.");
                return;
            }

            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtDescription.Text))
            {
                Message("Debes llenar los campos.");
                return;
            }
            Stream img = await Sign.GetImageStreamAsync(SignaturePad.Forms.SignatureImageFormat.Png);
            var mStream = (MemoryStream)img;
            Byte[] bytes = mStream.ToArray();
            var signature = new firma()
            {
                Id = 0,
                Name = txtName.Text,
                Description = txtDescription.Text,
                ArrayByteImage = bytes
            };


            var folderPath = "/storage/emulated/0/Android/data/com.companyname.ejer2_2michelle/files/Pictures";
            var nameSignature = "";
            if (await new Service.Service().saveSignatures(signature))
            {

                try
                {

                    if (!Directory.Exists(folderPath))
                        Directory.CreateDirectory(folderPath);
                    nameSignature = txtName.Text + DateTime.Now.ToString("MMddyyyyhhmmss"); ;

                    File.WriteAllBytes(folderPath + "/" + nameSignature + ".png", signature.ArrayByteImage);

                    Message("La firma se guardo correctamente!! \nPath:" + folderPath + "/" + nameSignature + ".png");
                }
                catch
                {
                    Message("La firmar se guardo correctamente!!");
                }



                clear();
            }
            else Message("La firma no se pudo guardar correctamente!!");

        }


        private void clear()
        {
            txtName.Text = null;
            txtDescription.Text = null;

            Sign.Clear();
        }

        public async void Message(string msg)
        {
            await DisplayAlert("Notificacion", msg, "OK");
        }

    }
}