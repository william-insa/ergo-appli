using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;


// Pour en savoir plus sur le modèle d'élément Page vierge, consultez la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace MyDomotik
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class AdminPage : Page
    {

        public AdminPage()
        {
            this.InitializeComponent();
        }

        private void exitAdmin(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void menuAdmin(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AdminPage));
        }

        private void gestionIcones(object sender, RoutedEventArgs e)  // remplace les boutons du menu Menu par le menu Gestion icônes
        {
            admin_buttons_grid.Children.RemoveAt(3);
            admin_buttons_grid.Children.RemoveAt(2);

            RowDefinitionCollection defs = admin_buttons_grid.RowDefinitions;
            defs.RemoveAt(2);
            defs.RemoveAt(1);

            admin_button_1.Content = "Gestion des pièces";
            admin_button_2.Content = "Gestion des équipements";

            admin_button_1.Click -= accesParamInterface;
            admin_button_1.Click += accesGestionPieces;

            admin_button_2.Click -= gestionIcones;
            admin_button_2.Click += accesGestionEquip;

            admin_button_3.Click -= accesParamInterface;
            admin_button_3.Click += accesPageReseau;

            page_title.Text = "Gestion des icônes";

            TextBlock t = new TextBlock();
            t.Foreground = new SolidColorBrush(Colors.Black);
            t.Text = "Menu";
            retourMenuAdmin.Content = t;
            retourMenuAdmin.IsEnabled = true;
        }

        private void accesParamInterface(object sender, RoutedEventArgs e)
        {
            admin_buttons_grid.Children.RemoveAt(3);
            
            RowDefinitionCollection defs = admin_buttons_grid.RowDefinitions;
            defs.RemoveAt(2);

            admin_button_1.Content = "Couleurs";
            admin_button_2.Content = "Tailles icônes";
            admin_button_3.Content = "Mode défilement";

            admin_button_1.Click -= accesParamInterface;
            admin_button_1.Click += accesParamCouleur;
            
            admin_button_2.Click -= gestionIcones;
            admin_button_2.Click += accesParamTaille;

            admin_button_3.Click -= accesParamInterface;
            admin_button_3.Click += accesParamDefil;

            page_title.Text = "Paramètres de l'interface";
            
            TextBlock t = new TextBlock();
            t.Foreground = new SolidColorBrush(Colors.Black);
            t.Text = "Menu";
            retourMenuAdmin.Content = t;
            retourMenuAdmin.IsEnabled = true;
        }

        private void accesParamCouleur(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ReglagesCouleur));
        }

        private void accesParamTaille(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ReglagesTailleIcones));

        }

        private void accesParamDefil(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ReglagesModeSelection));
        }

        private void accesGestionPieces(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(GestionIcones));
        }

        private void accesGestionEquip(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(GestionIcones2));
        }

        private void accesPageReseau(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ReglagesReseau));
        }
    }
}
