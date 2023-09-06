using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Graphics.Text;
using Microsoft.Maui.Layouts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using UniVerse.Components;
using UniVerse.Models;
using UniVerse.ViewModels;
//using static Java.Util.Jar.Attributes;

namespace UniVerse.Screens
{

    public class StudentOverviewScreen : ContentPage
    {
        public int StudentId { get; private set; }
        private PeopleViewModel _viewModel;

        private readonly Label name;
        private readonly Label role;
        private readonly Label mail;
        private readonly Label cell;
        private readonly Label studentNumber;
        private int achievedCredits;
        private int neededCredites;

        private List<SubjectEnrollments> enrollments;
        private readonly FlexLayout layout;

        public StudentOverviewScreen()
        {
            _viewModel = new PeopleViewModel(new Services.RestService());

            Shell.SetBackgroundColor(this, Color.FromArgb("#F6F7FB"));
            Style textStyle = new(typeof(Label))
            {
                Setters =
                {
                    new Setter { Property = Label.FontSizeProperty, Value =  16},
                    new Setter { Property = Label.TextColorProperty, Value = Color.FromArgb("#2B2B2B") }
                }
            };

            // Top 
            Image image = new()
            {
                Aspect = Aspect.AspectFill,
                MaximumHeightRequest = 200,
                MaximumWidthRequest = 200,
                Source = ImageSource.FromFile("student_profile.png"),
            };

            var clip1 = new EllipseGeometry { Center = new Point(200 / 2, 200 / 2), RadiusX = 200 / 2, RadiusY = 200 / 2 };

            image.Clip = clip1;

            Border imgBorder = new()
            {
                MaximumHeightRequest = 210,
                MaximumWidthRequest = 210,
                StrokeShape = new Ellipse(),
                HorizontalOptions = LayoutOptions.Center,
                StrokeThickness = 6,
                //Margin = new Thickness(0, -7, 0, 15),
                Stroke = Color.FromArgb("#407BFF"),
                Content = image

            };

            name = new Label
            {
                Text = "Bronwyn Pottie",
                TextColor = Color.FromArgb("#2B2B2B"),
                FontAttributes = FontAttributes.Bold,
                FontSize = 24
            };

            studentNumber = new Label
            {
                Text = "200211",
                TextColor = Color.FromArgb("#C5C5C5"),
                FontAttributes = FontAttributes.Bold,
                FontSize = 18,
              
            };

            role = new Label
            {
                Text = "\U0001F9D1 Degree student",
                Style = textStyle,
                Margin = new Thickness(0, 20, 0, 0)
            };

            cell = new Label
            {
                Text = "\U0000260E 076 887 6675",
                Style = textStyle,
            };

            mail = new Label
            {
                Text = "📧 Armand@OpenWindow.co.za",
                Style = textStyle,
            };

            StackLayout stackLayout = new()
            {
                Padding = new Thickness(10, 0),
                Margin = new Thickness(30, 15, 0, 0),

                Children =
                {
                    name,
                    studentNumber,
                    role,
                    cell,
                    mail
                }
            };

            FlexLayout topContainer = new()
            {
                Direction = FlexDirection.Row,

                Children =
                {
                    imgBorder,
                    stackLayout,
                }
            };

            // Cards

            layout = new FlexLayout()
            {
                Direction = FlexDirection.Row,
                Wrap = FlexWrap.Wrap,
                JustifyContent = FlexJustify.Start,
                AlignItems = FlexAlignItems.Start,
            };

            enrollments = new List<SubjectEnrollments>();

            ScrollView scrollView = new()
            {

                Content = layout
            };

            StudentOverViewRightBar right = new();

            Grid grid = new()
            {
                RowDefinitions = new RowDefinitionCollection
                {
                    new RowDefinition{Height = 245},
                    new RowDefinition{Height = GridLength.Star}
                },

                ColumnDefinitions = new ColumnDefinitionCollection
                {
                     new ColumnDefinition { Width = new GridLength(70, GridUnitType.Star) },
                     new ColumnDefinition { Width = new GridLength(30, GridUnitType.Star) }
                }
            };


            grid.Children.Add(topContainer);
            Grid.SetRow(topContainer, 0);
            Grid.SetColumn(topContainer, 0);
            Grid.SetColumnSpan(topContainer, 1);

            grid.Children.Add(scrollView);
            Grid.SetRow(scrollView, 1);
            Grid.SetColumn(scrollView, 0);
            Grid.SetColumnSpan(scrollView, 1);
            grid.BackgroundColor = Color.FromArgb("#F6F7FB");

            grid.Children.Add(right);
            Grid.SetColumn(right, 1);
            Grid.SetColumnSpan(right, 2);
            Grid.SetRowSpan(right, 2);


            grid.BackgroundColor = Color.FromArgb("#F6F7FB");
            grid.Padding = 6;


            Content = grid;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (BindingContext is NavOverviewViewModel viewModel)
            {
                if (viewModel.NavigationParameter is int memberIdValue)
                {
                    StudentId = memberIdValue;
                }
            }

            var student = await _viewModel.GetStudent(StudentId);

            if (student != null)
            {
                name.Text = student.student_name;
                role.Text = student.role;
                mail.Text = student.email;
                cell.Text = student.student_phoneNumber;
                achievedCredits = student.person_credits;
                neededCredites = student.needed_credits;
                studentNumber.Text = student.person_system_identifier;

                enrollments = student.enrollments;

                CreateAndAddEnrollmentCards();
            }
        }

        private void CreateAndAddEnrollmentCards()
        {
            layout.Children.Clear();

            foreach (var enrollment in enrollments)
            {
                var card = new EnrolledSubjects(enrollment.subject_name, enrollment.subject_code, enrollment.subject_color)
                {
                    BindingContext = enrollment
                };
                FlexLayout.SetBasis(card, new FlexBasis(0.50f, true));
                layout.Children.Add(card);
            }
        }
    }
}