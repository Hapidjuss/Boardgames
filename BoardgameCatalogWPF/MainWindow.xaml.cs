using Szewczyk.Boardgames.GUI.ViewModel;
using Szewczyk.Boardgames.GUI.Properties;
using Szewczyk.Boardgames.BLC;
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

namespace Szewczyk.Boardgames.GUI
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static public Szewczyk.Boardgames.BLC.BLC BLC;

        private Settings sett = new Settings();

        public MainWindow()
        {
            BLC = new Szewczyk.Boardgames.BLC.BLC(sett.DBNameConf);
            InitializeComponent();
        }
    }
}
