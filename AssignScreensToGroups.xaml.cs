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
using System.Windows.Shapes;

namespace Grouping
{
    /// <summary>
    /// Interaction logic for AssignScreensToGroups.xaml
    /// </summary>
    public partial class AssignScreensToGroups : Window
    {
        public StackPanel sp = new StackPanel();
        public MainWindow Y;

        public object Children { get; }

        public AssignScreensToGroups(string NumGroup,string NumScreen,MainWindow X)
        {
            
            Y = X;
            InitializeComponent();
            if(NumGroup == null)
            {
                NumGroup="5";
            }
            for (int i = 1;i < int.Parse(NumGroup) +1;i++)
            {
                
                comboBox.Items.Add(i);
            }
            for (int i = 1; i < int.Parse(NumScreen) + 1; ++i)
            {
                Button button = new Button()
                {
                    Content = string.Format(i.ToString(), i),
                    Tag = i,
                    Background = Brushes.Aqua
                    
                };
                if(Y.Ct > 0)
                {
                    for (int k = 1; k < int.Parse(Y.NumOfGroups) + 1; k++)
                    {
                        for (int j = 0; j < Y.groups[k - 1].ScreenId.Count; j++)
                        {
                            if (Y.groups[k - 1].ScreenId[j] == i)
                            {
                                button.Background = Brushes.Blue;
                            }
                        }
                    }

                }
                
                button.Click += new RoutedEventHandler(button_Click);
                this.grid.Children.Add(button);
            }
            

                
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (comboBox.SelectedIndex > -1)
            {
                Button conBut = (Button)sender;
                string con = conBut.Content.ToString();


                for (int i = 1; i < int.Parse(Y.NumOfGroups) + 1; i++)
                {
                    string t = comboBox.SelectedItem.ToString();
                    if (Y.groups[i - 1].Group_Id == int.Parse(t))
                    {

                        if (conBut.Background == Brushes.Blue)
                        {
                            for (int k = 1; k < int.Parse(Y.NumOfGroups) + 1; k++)

                                for (int j=0;j<Y.groups[k-1].ScreenId.Count;j++)
                                {
                                
                                     if(Y.groups[k - 1].Group_Id.ToString()==t&& Y.groups[k - 1].ScreenId[j] ==int.Parse(con))
                                     {
                                        Y.groups[k-1].ScreenId.RemoveAt(j);
                                        conBut.Background = Brushes.Aqua;
                                        break;


                                     }
                                
                                }
                            
                        }
                        else
                        {
                            conBut.Background = Brushes.Blue;
                            Y.groups[i - 1].ScreenId.Add(int.Parse(con));
                        }

                    }

                }

            }

            //MessageBox.Show("ok");
            //for (int i = 1; i < int.Parse(Y.NumOfGroups) + 1; i++)
            //{

            //    if (int.Parse(comboBox.SelectedItem.ToString()) == Y.groups[i - 1].Group_Id)
            //    {
            //        if (!conBut.IsEnabled && )
            //        {

            //        }
            //    }
            //}
        }
    }
}
