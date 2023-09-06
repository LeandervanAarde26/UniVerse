using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Layouts;
using System.Diagnostics;
using UniVerse.ViewModels;

namespace UniVerse.Components
{


    public class RightBar : ContentView
    {
        private PeopleViewModel viewModel;
        public string PageType { get; set; }
        public List<String> DropList {get; set; }

        public int _selectedRoleIndex;


        public RightBar(string pgType, List<String> dropLst)
        {
            viewModel = new PeopleViewModel(new Services.RestService());
            BindingContext = viewModel;
            PageType = pgType;
            DropList = dropLst;
            Style inputStyle = new(typeof(Entry))
            {
                Setters =
                {
                    new Setter { Property = InputView.BackgroundColorProperty, Value = Color.FromArgb("#F6F7FB") },
                    new Setter { Property = InputView.MarginProperty, Value = new Thickness(22, 5) },
                    new Setter { Property = InputView.TextColorProperty, Value = Color.FromArgb("#2B2B2B") }
                }
            };

            ProfileView profileContainer = new();

            Label heading = new()
            {
                Text = "Add new " + PageType,
                FontSize = 20,
                HorizontalOptions = LayoutOptions.Start,
                Margin = new Thickness(22, 5),
                TextColor = Color.FromArgb("#2B2B2B"),
                FontAttributes = FontAttributes.Bold,

            };


            Image defaultimage = new()
            {
                Source = ImageSource.FromFile("image_picker.png"),
                Aspect = Aspect.AspectFit,
                MaximumHeightRequest = 230,
                MaximumWidthRequest = 200,
            };

            Button imageUploadButton = new()
            {
                Text = "Upload Image",
                BackgroundColor = Colors.Transparent,
                FontSize = 12,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.End,
                Margin = new Thickness(5,0),
                TextColor = Color.FromArgb("#407BFF"),
            };

            imageUploadButton.Clicked += async (sender, e) =>
            {
                var imagePickerOptions = new PickOptions
                {
                    PickerTitle = "Select an image",
               
                };

                var selectedImage = await GetImage(imagePickerOptions);
                if (selectedImage != null)
                {
           
                    defaultimage.Source = selectedImage.FullPath;
                }
            };


            FlexLayout innerLayout = new()
            {
                MaximumHeightRequest = 200,
                MaximumWidthRequest = 200,

                Direction = FlexDirection.Column,
                Children =
                {
                    defaultimage,
                    imageUploadButton
                }
            };

            Border border = new()
            {
                StrokeThickness = 1,
                Stroke = Color.FromArgb("#2B2B2B"),
                StrokeDashArray = new DoubleCollection(new double[] { 8, 3 }),
                HeightRequest = 230,
                StrokeDashOffset = 6,
                Content = innerLayout,
                BackgroundColor = Color.FromArgb("#F6F7FB"),
                Margin = new Thickness(22, 8),
                Padding = new Thickness(10,2),
                StrokeShape = new RoundRectangle
                {
                    CornerRadius = new CornerRadius(6)
                },
            };

            Entry name = new()
            {
                Placeholder = PageType +  " Name",
                Style = inputStyle

            };
            name.SetBinding(Entry.TextProperty, new Binding("NameEntry", source: viewModel));


            Entry surname = new()
            {
                Placeholder = PageType +  " Surname",
                Style = inputStyle
            };
            surname.SetBinding(Entry.TextProperty, new Binding("SurnameEntry", source: viewModel));

            Entry studentNumber = new()
            {
                Placeholder = PageType + " Number",
                Style = inputStyle
            };
            studentNumber.SetBinding(Entry.TextProperty, new Binding("Identifier", source: viewModel));

            var listOptions = DropList;

            Picker studentRole = new()
            {
                Style = inputStyle,
              

            };

             foreach (var option in listOptions)
            {
                studentRole.Items.Add(option);
            }
            studentRole.SelectedItem = PageType + " Type";
            studentRole.TextColor = Colors.Black;
            studentRole.TitleColor = Colors.Black;

            studentRole.SetBinding(Picker.SelectedIndexProperty, new Binding("RoleInput", source: viewModel));



            StackLayout showcase = new()
            {
                
                Children =
                {
                    studentNumber,
                    studentRole
                }
            };


            FlexLayout showcase2 = new()
            {
                Direction = FlexDirection.Row,
                Children =
                {
                    studentNumber,
                    studentRole
                }
            };

            Entry email = new()
            {
                Placeholder = PageType + " Email",
                Style = inputStyle

            };
            email.SetBinding(Entry.TextProperty, new Binding("EmailEntry", source: viewModel));

            Entry phoneNumber = new()
            {
                Placeholder =  PageType + " Number",
                Style = inputStyle,
                MaxLength = 10
            };
            phoneNumber.SetBinding(Entry.TextProperty, new Binding("Number", source: viewModel));

            Button button = new()
            {
                Text =  "Add " + PageType,
                BackgroundColor = Color.FromArgb("#2B2B2B"),
                Margin = new Thickness(18, 6)
            };

            button.Clicked += async (sender, e)  => { await viewModel.AddStudent(); };

            StackLayout stack = new()
            {
                VerticalOptions = LayoutOptions.Center,
                Children =
                {
                    heading,
                    border,
                    name,
                    surname,
                    //showcase,
                    //showcase2,
                    studentNumber,
                    studentRole,
                    email,
                    phoneNumber,
                    button
                }
            };

            FlexLayout layout = new()
            {
                BackgroundColor = Colors.White,
                Direction = FlexDirection.Column,

                JustifyContent = FlexJustify.Start,
                Children =
                {
                    profileContainer,
                    stack
                },

               
            };
            //FlexLayout.SetGrow(stack, 1);
            Content = layout;
        }


        public async Task<FileResult> GetImage(PickOptions pickOptions)
        {
            var result = await FilePicker.PickAsync(pickOptions);
            try
            {
                if (result != null)
                {
                    if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
                           result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
                    {
                        using var stream = await result.OpenReadAsync();
                        var iamge = ImageSource.FromStream(() => stream);

                        return result;
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return null;
        }
    }
}
