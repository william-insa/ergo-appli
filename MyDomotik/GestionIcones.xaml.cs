using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Windows;
//﻿using InstanceFactory.MessageBoxSample.UI.Popups;
using System.Threading.Tasks;
using Windows.UI.Popups;
using System.Text;
using Windows.UI;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Shapes;
//using System.Object;
//using System.Drawing;

// Pour en savoir plus sur le modèle d'élément Page vierge, consultez la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace MyDomotik
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class GestionIcones : Page
    {
       public Image image;
       private static Grille g = new Grille(Format.MOYEN); 
       private Affichage affich = new Affichage(g, new Theme());
       private Icone icone;
       public String nom ;
       public Button b ;
     


     /*  public List<System.Drawing.Image> listeIconesPiece = new List<System.Drawing.Image>();
       private List<BitmapImage> listeIconesEquip = new List<BitmapImage>();
      
        System.Drawing.Image bathroom =  System.Drawing.Image.FromFile("Assets/ICONS_MDTOUCH/size_64x64/bathroom_0.png");
        BitmapImage livingroom = new BitmapImage();
        BitmapImage house1 = new BitmapImage();
        BitmapImage house2 = new BitmapImage();
        BitmapImage bedroom = new BitmapImage();
        BitmapImage kitchen = new BitmapImage();
        BitmapImage garage = new BitmapImage();
        BitmapImage garden = new BitmapImage();
        BitmapImage diningroom = new BitmapImage();
        BitmapImage office = new BitmapImage();
        BitmapImage patio = new BitmapImage();

       */

        public GestionIcones()
        {
            this.InitializeComponent();
          /*  bathroom.UriSource = new Uri("ms-appx:///Assets/ICONS_MDTOUCH/size_64x64/bathroom_0.png", UriKind.Absolute);
            livingroom.UriSource = new Uri("ms-appx:///Assets/ICONS_MDTOUCH/size_64x64/livingroom_0.png", UriKind.Absolute);
            house1.UriSource = new Uri("ms-appx:///Assets/ICONS_MDTOUCH/size_64x64/house1_0.png", UriKind.Absolute);
            house2.UriSource = new Uri("ms-appx:///Assets/ICONS_MDTOUCH/size_64x64/house2_0.png", UriKind.Absolute);
            bedroom.UriSource = new Uri("ms-appx:///Assets/ICONS_MDTOUCH/size_64x64/bedroom_0.png", UriKind.Absolute);
            kitchen.UriSource = new Uri("ms-appx:///Assets/ICONS_MDTOUCH/size_64x64/kitchen_0.png", UriKind.Absolute);
            garage.UriSource = new Uri("ms-appx:///Assets/ICONS_MDTOUCH/size_64x64/garage_0.png", UriKind.Absolute);
            garden.UriSource = new Uri("ms-appx:///Assets/ICONS_MDTOUCH/size_64x64/garden_0.png", UriKind.Absolute);
            diningroom.UriSource = new Uri("ms-appx:///Assets/ICONS_MDTOUCH/size_64x64/diningroom_0.png", UriKind.Absolute);
            office.UriSource = new Uri("ms-appx:///Assets/ICONS_MDTOUCH/size_64x64/office_0.png", UriKind.Absolute);
            patio.UriSource = new Uri("ms-appx:///Assets/ICONS_MDTOUCH/size_64x64/patio_0.png", UriKind.Absolute);

            listeIconesPiece.Add(bathroom); listeIconesPiece.Add(livingroom); listeIconesPiece.Add(house1); listeIconesPiece.Add(house2);
            listeIconesPiece.Add(bedroom); listeIconesPiece.Add(kitchen); listeIconesPiece.Add(garage); listeIconesPiece.Add(garden);
            listeIconesPiece.Add(diningroom); listeIconesPiece.Add(office); listeIconesPiece.Add(patio);
            

            listeIconesPiece.Add(bathroom);
            BarIconePiece.ItemsSource = listeIconesPiece;*/
        }

        public void exitAdmin(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        public void menuAdmin(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AdminPage));
            
        }

        private void goToIcones(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(GestionIcones2));
        }

        //événement qui gère le double click sur une icone
        //affiche un mesage pour le choix de l'emplacement de l'icone dans la grille et récupère les informations sur l'icone
        private void choixImage(object sender, DoubleTappedRoutedEventArgs e)
        {
            messageBox.Visibility = Visibility.Visible;
            message.Text = "Veuillez clicker sur l'endroit où vous souhaitez inserer l'icone";

            image = sender as Image;
          
            
        }

        //événement qui gère le click sur un bouton
        //affiche l'icone double clickée sur le bouton
        private void choixPositionIcone(object sender, RoutedEventArgs e)
        {
            b = sender as Button;
            nom = image.Name.Replace("é", ".");

            icone = new Icone("h", nom , 64, new Navigation(new Vue("pageIcones")));
            affich.afficherIcone(icone, b);
            message.Text = "Veuillez attribuer un nom à l'icone";
            nomIcone.Visibility = Visibility.Visible;
            Valider.Visibility = Visibility.Visible;
            
        }

        private void Validation(object sender, RoutedEventArgs e)
        {
            icone = new Icone(nomIcone.Text, nom, 64, new Navigation(new Vue("pageIcones")));
            affich.afficherIcone(icone, b);
            message.Text = "";
            messageBox.Visibility = Visibility.Collapsed;
            nomIcone.Visibility = Visibility.Collapsed;
            Valider.Visibility = Visibility.Collapsed;
        }
            

      /*  private void enleverIcone(object sender, DoubleTappedRoutedEventArgs e)
        {
            Button b = sender as Button;
            String nom = image.Name.Replace("é", ".");
            Icone icone = new Icone("house", nom, 64, new Navigation(new Vue("page")));
            affich.cacherIcone(icone, b);
        }

       */

    }
}
