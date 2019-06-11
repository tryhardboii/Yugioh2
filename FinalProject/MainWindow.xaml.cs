using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Start_G_Click(object sender, RoutedEventArgs e)
        {
            InGame OP = new InGame();
            OP.Show();
            this.Close();

            string demox = FinalProject.MainDB.DB();
            MessageBox.Show(demox);

        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            string News = UpdateCard.Start();
            try
            {
                StreamWriter sw = new StreamWriter("DB.json");
                sw.Write(News);
                sw.Close();
            }   catch (Exception s) {
                MessageBox.Show(s.Message);
            } finally
            {
                MessageBox.Show("Updated!");
            }

        }
    }
}
