using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace prov_wpf_e2_TE23E_Eli_Graseman;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();


    }

    List<string> PassLista = [];

    private void KlickVisa(object sender, RoutedEventArgs e)
    {
        string Aktivitet = txbAktivitet.Text;
        string Längd = txbLangd.Text;
        string Intensitet = txbIntensitet.Text;

        if (Aktivitet == "")
        {
            txbPass.Text = $"Var snäll och ange aktivitet";
        }
        else
        {
            if (Intensitet != "Medel" && Intensitet != "Låg" && Intensitet != "Hög")
            {
                txbPass.Text = "Felaktig intensitet";
            }
            else
            {
                if (int.TryParse(txbLangd.Text, out int Tiden) && Tiden <= 180 && Tiden >= 0)
                {
                    txbPass.Text = $"Aktivitet:{Aktivitet}\nLängd(min):{Längd}\nIntensitet:{Intensitet}";
                }
                else
                {
                    txbPass.Text = "Ogiltig längd";
                }
            }


        }

    }

    private void KlickSpara(object sender, RoutedEventArgs e)
    {

        PassLista.Add(txbPass.Text);
    }

    private void KlickVisaPass(object sender, RoutedEventArgs e)
    {
        foreach (var Pass in PassLista)
        {
            txbLista.Text += Pass;
        }
    }

    private void KlickVisaStatistik(object sender, RoutedEventArgs e)
    {
        string AntalPass = txbAntalPass.Text;
        string TotalLängd = txbTotalMinuter.Text;
        string LängstaPass = txbMaxMinuter.Text;
        
        txbAntalPass.Text = txbLista.Text + 1;

    }




}