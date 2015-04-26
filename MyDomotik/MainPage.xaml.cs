using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
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
using Windows.UI;


namespace MyDomotik
{
    public sealed partial class MainPage : Page
    {

        public MainPage()
        {
            this.InitializeComponent();
            this.displayTime();
            this.afficheCouleur(new Couleur()); // il faut passer la couleur attribut de la classe configuration
        }

        // Affiche les couleurs de la grille, la barre de menu et ses boutons en fonction du thème de couleurs passé en paramètre
        private void afficheCouleur(Couleur couleur)
        {

            Brush grille = new SolidColorBrush(couleur.CouleurGrille);
            Brush barre = new SolidColorBrush(couleur.CouleurBarre);
            Brush boutons = new SolidColorBrush(couleur.CouleurIconeBarre);

            barreMenu.Fill = barre;
            cadre.Background = grille;
            accueil.Background = boutons;
            precedent.Background = boutons;
            suivant.Background = boutons;
    
        }
        private void displayTime()
        {
            TimeBox.Text = DateTime.Now.ToString();
        }

       

        private void adminSelect(object sender, DoubleTappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AdminPage));
        }

      


    }
}
