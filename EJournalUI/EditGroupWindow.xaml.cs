﻿using EJournalBLL.Services;
using EJournalBLL.Models;
using System.Configuration;
using System.Windows;

namespace EJournalUI
{
    /// <summary>
    /// Interaction logic for AddGroupWindow.xaml
    /// </summary>
    public partial class EditGroupWindow : Window
    {
        public Group Group;
        public EditGroupWindow(DialogWindowType dialogWindowType)
        {
            InitializeComponent();

            CoursesService coursesService = new CoursesService();
            CourseComboBox.ItemsSource = coursesService.Courses;
            ConfigWindow(dialogWindowType);
        }

        private void Butto_CreateGroup_Accept_Click(object sender, RoutedEventArgs e)
        {
            if (NameTextBox.Text != string.Empty
                && CourseComboBox.SelectedItem != null)
            {
                Group = new Group(NameTextBox.Text, (Course)CourseComboBox.SelectedItem);
                this.DialogResult = true;
            }
        }

        private void Butto_EditGroup_Accept_Click(object sender, RoutedEventArgs e)
        {
            Group.Name = NameTextBox.Text;
            Group.Course = (Course)CourseComboBox.SelectedItem;

            this.DialogResult = true;
        }

        private void Button_EditCourse_Accept_Click(object sender, RoutedEventArgs e)
        {
            if (NameTextBox.Text != string.Empty
                && CourseComboBox.SelectedItem != null)
            {
                Course course = (Course)CourseComboBox.SelectedItem;
                course.Name = NameTextBox.Text;
                CoursesService coursesService = new CoursesService();
                coursesService.UpdateCourse(course);
                this.DialogResult = true;
            }
        }

        private void Button_CreateCourse_Accept_Click(object sender, RoutedEventArgs e)
        {
            if (NameTextBox.Text != string.Empty)
            {
                CoursesService coursesService = new CoursesService();
                coursesService.AddCourse(new EJournalBLL.Models.Course(NameTextBox.Text));
                this.DialogResult = true;
            }
        }

        private void ConfigWindow(DialogWindowType dialogWindowType)
        {
            switch (dialogWindowType)
            {
                case DialogWindowType.AddGroup:
                    Title = "Create new Gourse";
                    TitleTextBlock.Text = "New course name";
                    AcceptButton.Click += Butto_CreateGroup_Accept_Click;
                    break;

                case DialogWindowType.EditGroup:
                    Title = "Edit group";
                    TitleTextBlock.Text = "New group name";
                    AcceptButton.Click += Butto_EditGroup_Accept_Click;
                    break;

                case DialogWindowType.AddCourse:
                    Title = "Create Course";
                    TitleTextBlock.Text = "New course name";
                    ComboBoxNameTextBlock.Visibility = Visibility.Hidden;
                    CourseComboBox.IsEditable = false;
                    CourseComboBox.Visibility = Visibility.Hidden;
                    AcceptButton.Click += Button_CreateCourse_Accept_Click;
                    break;

                case DialogWindowType.EditCourse:
                    Title = "Edit Course";
                    TitleTextBlock.Text = "New course name";
                    AcceptButton.Click += Button_EditCourse_Accept_Click;
                    break;
            }
        }
    }
}