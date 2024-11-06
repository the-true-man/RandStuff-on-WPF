using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Drawing;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.Remoting.Channels;
using System.Collections;

namespace randomized
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void count_nums_slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            count_nums_slider.Value = Math.Truncate(count_nums_slider.Value);

            if (count_nums_slider.Value % 10 == 1 && count_nums_slider.Value!=11)
            {
                label_random_nums_slova.Content = "случайного числа";
            }
            else
            {
                label_random_nums_slova.Content = "случайных чисел";
            }
            


        }
        int start;
        int finish;
        int max_count_num;
        int count_num;
        Random rnd = new Random();
        private void repeat_and_dont_delete()
        {
            label_display_nums.Text = "";
            start = int.Parse(tb_start.Text);
            finish = int.Parse(tb_finish.Text);
            max_count_num = (int)count_nums_slider.Value;
            count_num = 0;


            while(count_num<max_count_num)
            {
                count_num++;
                try
                {
                    num = rnd.Next(start, finish + 1);
                }
                catch
                {
                    num = rnd.Next(finish, start + 1);
                }
                label_display_nums.Text += num.ToString() + "   ";
            }

            

        }
        private void dont_repeat_and_dont_delete()
        {
            label_display_nums.Text = "";
            start = int.Parse(tb_start.Text);
            finish = int.Parse(tb_finish.Text);
            max_count_num = (int)count_nums_slider.Value>(finish-start) ? (finish-start+1) : (int)count_nums_slider.Value;
            count_num = 0;
            List<int> nums = new List<int>();

            while (count_num < max_count_num)
            { 
                try
                {
                    num = rnd.Next(start, finish + 1);
                }
                catch
                {
                    num = rnd.Next(finish, start + 1);
                }
                if(!nums.Contains(num))
                {
                    count_num++;
                    nums.Add(num);
                    label_display_nums.Text += num.ToString() + "   ";
                }
                
            }
        }
        private void dont_repeat_and_delete()
        {
            label_display_nums.Text = "";
            start = int.Parse(tb_start.Text);
            finish = int.Parse(tb_finish.Text);
            count_num = 0;
            List<int> nums = new List<int>();
            List<int> del_nums = new List<int>();
            foreach (char ch in delete_num_list.Text)
            {
                if (int.TryParse(ch.ToString(), out int value) && ch != ' ')
                {
                    temp += ch.ToString();
                }
                else
                {
                    if (temp.Trim() != string.Empty)
                    {
                        num = int.Parse(temp);
                        if (!del_nums.Contains(num))
                        {
                            del_nums.Add(num);
                        }
                        temp = string.Empty;
                    }
                }
            }
            if (temp != string.Empty)
            {
                del_nums.Add(int.Parse(temp));
                temp = string.Empty;
            }
            List<int> qwe = new List<int>();
            List<int> zxc = new List<int>();
            for (int i = start; i <= finish; i++)
            {
                qwe.Add(i);
            }
            zxc = qwe.Except(del_nums).ToList();
            max_count_num = zxc.Count;
            while (count_num < max_count_num)
            {
                try
                {
                    num = rnd.Next(start, finish + 1);
                }
                catch
                {
                    num = rnd.Next(finish, start + 1);
                }
                if (!nums.Contains(num) && !del_nums.Contains(num))
                {
                    count_num++;
                    nums.Add(num);
                    del_nums.Add(num);
                    label_display_nums.Text += num.ToString() + "   ";
                }
            }
        }
        private void repeat_and_delete()
        {
            label_display_nums.Text = "";
            start = int.Parse(tb_start.Text);
            finish = int.Parse(tb_finish.Text);
            count_num = 0;
            
            List<int> del_nums = new List<int>();
            foreach (char ch in delete_num_list.Text)
            {
                if (int.TryParse(ch.ToString(), out int value) && ch != ' ')
                {
                    temp += ch.ToString();
                }
                else
                {
                    if (temp.Trim() != string.Empty)
                    {
                        num = int.Parse(temp);
                        if (!del_nums.Contains(num))
                        {
                            del_nums.Add(num);
                        }
                        temp = string.Empty;
                    }
                }
            }
            if (temp != string.Empty)
            {
                del_nums.Add(int.Parse(temp));
                temp = string.Empty;
            }
            //max_count_num = (int)count_nums_slider.Value > (finish - start - del_nums.Count) ? (finish - start + 1 - del_nums.Count) : (int)count_nums_slider.Value;
            max_count_num = (int)count_nums_slider.Value;
            if(finish<= del_nums.Count)
            {
                return;
            }
            while (count_num < max_count_num)
            {
                try
                {
                    num = rnd.Next(start, finish + 1);
                }
                catch
                {
                    num = rnd.Next(finish, start + 1);
                }
                if (!del_nums.Contains(num))
                {
                    count_num++;
                    label_display_nums.Text += num.ToString() + "   ";
                }

            }
        }
        private void random_num_in_list()
        {
            int count_num = 0;
            max_count_num = (int)count_nums_slider.Value;
            label_display_nums.Text = "";
            ints.Clear();
            List<int> del_nums = new List<int>();
            List<int> nums = new List<int>();
            
            if (delete_num.IsChecked == true)
            {
                foreach (char ch in delete_num_list.Text)
                {
                    if (int.TryParse(ch.ToString(), out int value) && ch != ' ')
                    {
                        temp += ch.ToString();
                    }
                    else
                    {
                        if (temp.Trim() != string.Empty)
                        {
                            num = int.Parse(temp);
                            if (!del_nums.Contains(num))
                            {
                                del_nums.Add(num);
                            }
                            temp = string.Empty;
                        }
                    }
                }
                if (temp != string.Empty)
                {
                    del_nums.Add(int.Parse(temp));
                    temp = string.Empty;
                }
            }
            foreach (char ch in tb_list.Text)
            {
                if (int.TryParse(ch.ToString(), out int value) && ch != ' ')
                {
                    temp += ch.ToString();
                }
                else
                {
                    if (temp.Trim() != string.Empty)
                    {
                        num = int.Parse(temp);

                        ints.Add(num);
                        temp = string.Empty;
                    }
                }
            }
            if (temp.Trim() != string.Empty)
            {
                ints.Add(int.Parse(temp));
                temp = string.Empty;
            }
            if(dont_repeat_nums.IsChecked == false && delete_num.IsChecked == false)
            {
                max_count_num = (int)count_nums_slider.Value;
                while (max_count_num > count_num)
                {
                    count_num++;
                    int index = rnd.Next(ints.Count);
                    label_display_nums.Text += " " + ints[index] + " ";
                }
            }
            else if(dont_repeat_nums.IsChecked == true && delete_num.IsChecked == false)
            {
                max_count_num = (int)count_nums_slider.Value>ints.Count ? ints.Count : (int)count_nums_slider.Value;
                while (max_count_num > count_num)
                {   

                    int index = rnd.Next(ints.Count);
                    if(!nums.Contains(ints[index]))
                    {
                        count_num++;
                        nums.Add(ints[index]);
                        label_display_nums.Text += " " + ints[index] + " ";
                    }
                    
                }
            }
            else if(dont_repeat_nums.IsChecked == false && delete_num.IsChecked == true)
            {
                max_count_num = (int)count_nums_slider.Value;
                if(ints.Count <= del_nums.Count)
                {
                    return;
                }
                while (max_count_num > count_num)
                {

                    int index = rnd.Next(ints.Count);
                    if (!del_nums.Contains(ints[index]))
                    {
                        count_num++;
                        label_display_nums.Text += " " + ints[index] + " ";
                    }

                }
            }
            else if (dont_repeat_nums.IsChecked == true && delete_num.IsChecked == true)
            {
                if (ints == del_nums)
                {
                    return;
                }
                
                List<int> qwe = new List<int>();
                qwe = ints.Except(del_nums).ToList();
                max_count_num = (int)count_nums_slider.Value > qwe.Count ? qwe.Count : (int)count_nums_slider.Value;
                ints = qwe;
                while (max_count_num > count_num)
                {
                    int index = rnd.Next(ints.Count);
                    if (!del_nums.Contains(ints[index]) && !nums.Contains(ints[index]))
                    {
                        count_num++;
                        nums.Add(ints[index]);
                        label_display_nums.Text += " " + ints[index] + " ";
                    }

                }
            }

        }
        private void generate_nums_button_Click(object sender, RoutedEventArgs e)
        {
            if(rb_diap.IsChecked == true && dont_repeat_nums.IsChecked == false && delete_num.IsChecked == false)
            {
                repeat_and_dont_delete();
                return;
            }
            if (rb_diap.IsChecked == true && dont_repeat_nums.IsChecked == true && delete_num.IsChecked == false)
            {
                dont_repeat_and_dont_delete();
                return;
            }
            if (rb_diap.IsChecked == true && dont_repeat_nums.IsChecked == true && delete_num.IsChecked == true)
            {
                dont_repeat_and_delete();
                return;
            }
            if (rb_diap.IsChecked == true && dont_repeat_nums.IsChecked == false && delete_num.IsChecked == true)
            {
                repeat_and_delete();
                return;
            }
            if(rb_diap.IsChecked == false)
            {
                random_num_in_list();
                return;
            }

            
            
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (e.Text == "-")
            {
                if (textBox.Text.Contains("-"))
                {
                    e.Handled = true;
                }
            }
            else if (!int.TryParse(textBox.Text + e.Text, out int value))
            {
                e.Handled = true;
            }
            else if (textBox.Text.Length + e.Text.Length > 8)
            {
                e.Handled = true;
            }
        }

        private void tb_start_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if(textBox.Text == "")
            {
                textBox.Text = "0";
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if(stack_panel_diapazon != null && stack_panel_list != null)
            {
                stack_panel_diapazon.Visibility = Visibility.Visible;
                stack_panel_list.Visibility = Visibility.Collapsed;
            }
            
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            if (stack_panel_diapazon != null && stack_panel_list != null)
            {
                stack_panel_list.Visibility = Visibility.Visible;
                stack_panel_diapazon.Visibility = Visibility.Collapsed;
            }
        }
        int num;
        string temp = "";
        List<int> ints = new List<int>();
        private void tb_list_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            
        }

        private void tb_list_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void delete_num_Checked(object sender, RoutedEventArgs e)
        {
            delete_num_list.Visibility= Visibility.Visible;
        }

        private void delete_num_Unchecked(object sender, RoutedEventArgs e)
        {
            delete_num_list.Visibility = Visibility.Collapsed;
        }

        private void tb_start_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tb_start.Text.Length > 7)
            {
                tb_start.Text = tb_start.Text.Remove(tb_start.Text.Length - 1);
            }
        }

        private void tb_finish_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tb_finish.Text.Length > 7)
            {
                tb_finish.Text = tb_finish.Text.Remove(tb_finish.Text.Length - 1);
            }
        }
    }
}
