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

namespace WpfApp11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Student> ListaStudentow { get; set; }
        public List<Ocena> ListaOcen { get; set; }

        public MainWindow()
        {

            ListaStudentow = new List<Student>() 
            {
                new Student(){imie="Jan",nazwisko="Kowalski",NrIndeksu=1234,Wydzial="KIS", ocena=6},
                new Student(){imie="Anna",nazwisko="Nowak",NrIndeksu=4321,Wydzial="KIS", ocena=5},
                 new Student(){imie="Michał",nazwisko="Jacek",NrIndeksu=34562,Wydzial="KIS",ocena=4},
             
             



            };
            ListaOcen = new List<Ocena>()
            {
                new Ocena(){ocena=6},
                new Ocena(){ocena=5 },
                 new Ocena(){ocena=6},


            };

            InitializeComponent();

            dgStudent.Columns.Add(new DataGridTextColumn() { Header = "Imie", Binding = new Binding("imie") });
            dgStudent.Columns.Add(new DataGridTextColumn() { Header = "Nazwisko", Binding = new Binding("nazwisko") });
            dgStudent.Columns.Add(new DataGridTextColumn() { Header = "NrIndeksu", Binding = new Binding("NrIndeksu") });
            dgStudent.Columns.Add(new DataGridTextColumn() { Header = "Wydzial", Binding = new Binding("Wydzial") });
            dgStudent.Columns.Add(new DataGridTextColumn() { Header = "Ocena", Binding = new Binding("ocena") });
            
            dgStudent.AutoGenerateColumns = false;
            dgStudent.ItemsSource = ListaStudentow;
        }

        private void bAddStudent_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new StudentWindow();
            if(dialog.ShowDialog()==true)
            {
                ListaStudentow.Add(dialog.student);
                dgStudent.Items.Refresh();
            }
        }

        private void bRemoveStudent1_Click(object sender, RoutedEventArgs e)
        {
            if(dgStudent.SelectedItem is Student)
            
                ListaStudentow.Remove((Student)dgStudent.SelectedItem);
                dgStudent.Items.Refresh();
            
        }
    }

}

