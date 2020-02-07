using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using TODO_App.Model;
using TODO_App.Services;

namespace TODO_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string PATH = $"{Environment.CurrentDirectory}\\todoDataList.json";
        private BindingList<TODO> todoDataList;
        private FileIOService fileIOService;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DgTodoList_Loaded(object sender, RoutedEventArgs e)
        {
            fileIOService = new FileIOService(PATH);

            try
            {
                todoDataList = fileIOService.LoadData();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }

            dgTodoList.ItemsSource = todoDataList;
            todoDataList.ListChanged += todoDataList_ListChanged;
        }

        private void todoDataList_ListChanged(object sender, ListChangedEventArgs e)
        {
            if(e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemChanged)
            {
                try
                {
                    fileIOService.SaveData(sender);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }
            }
        }
    }
}
