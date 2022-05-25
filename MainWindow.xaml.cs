using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace Grouping
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class group
        {
            public int Group_Id;
            public List<int> ScreenId = new List<int>();
        }
        public class student
        {
           public string Name;
           public string Email;
           public string Password;
           public int Group_Id;
        }
        public string NumOfScr = "50";
        public string NumOfGroups;
        public List<group> groups;
        public List<student> students;
        public int Ct = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string conString = "Data Source=localhost;Initial Catalog=ExampleDatabase;Integrated Security=True";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string selectSql = "select GroupID,Email,Password,Type,Screens from Grouping_Db Where Email=@Email";
            SqlCommand cmd = new SqlCommand(selectSql, con);
            cmd.Parameters.AddWithValue("Email","ahmed@on.com");
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            ChooseNumberOfScreens X = new ChooseNumberOfScreens(this,NumOfScr);
            X.Show();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(NumOfScr);
            AssignScreensToGroups X = new AssignScreensToGroups(NumOfGroups,NumOfScr,this);
            groups = new List<group>();
            for(int i=1;i<int.Parse(NumOfGroups)+1;i++)
            {
                group V = new group();
                V.Group_Id = i;
                groups.Add(V);
            }
            Ct++;
            X.Show();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            for(int i =0; i < groups.Count;i++)
            {
                MessageBox.Show("Group"+groups[i].Group_Id.ToString());
                for(int k = 0; k<groups[i].ScreenId.Count;k++ )
                {
                    MessageBox.Show("Screen"+groups[i].ScreenId[k].ToString());
                }
            }
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
