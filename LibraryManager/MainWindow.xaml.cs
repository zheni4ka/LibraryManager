using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace LibraryManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModel viewModel = new ViewModel();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }



    [AddINotifyPropertyChangedInterface]
    public class ViewModel
    {
        public bool checkPrev(Book currBook) { return books.IndexOf(currBook) == books.Count - 1; }
        public bool checkNext(Book currBook) { return books.IndexOf(currBook) == 0; }
        
        private ObservableCollection<Book> books = new ObservableCollection<Book>();
        public IEnumerable<Book> Books => books;

        private RelayCommand nextBook;
        private RelayCommand previusBook;
        public ICommand NextBook_ => nextBook;
        public ICommand PreviousBook_ => previusBook;

        void Next() { SelectedBook = books[books.IndexOf(SelectedBook) + 1]; }
        void Prev() { SelectedBook = books[books.IndexOf(SelectedBook) - 1]; }

        public Book SelectedBook { get; set; }
        public ViewModel()
        {
            books.Add(new Book("Chorna Rada", "Panteleymon Kulish", "a historical novel by the Ukrainian writer Panteleimon Kulish, which depicts a well-known historical event - the black council that took place in Nizhyn in 1663, recreates social contradictions in Ukraine after the victorious war of liberation and accession to the Muscovite kingdom.", 1857));
            books.Add(new Book("Chorna Rada1", "Panteleymon Kulish1", "a historical novel by the Ukrainian writer Panteleimon Kulish, which depicts a well-known historical event - the black council that took place in Nizhyn in 1663, recreates social contradictions in Ukraine after the victorious war of liberation and accession to the Muscovite kingdom.", 1857));
            SelectedBook = books[0];

            nextBook = new((obj) => Next(), (check) => checkNext(SelectedBook));
            previusBook = new((obj) => Prev(), (check) => checkPrev(SelectedBook));
        }


    }


}
