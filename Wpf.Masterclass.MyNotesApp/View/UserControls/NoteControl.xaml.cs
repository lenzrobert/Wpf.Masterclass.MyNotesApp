using System.Windows;
using System.Windows.Controls;
using Wpf.Masterclass.MyNotesApp.Model;

namespace Wpf.Masterclass.MyNotesApp.View.UserControls
{
    /// <summary>
    /// Interaction logic for NoteControl.xaml
    /// </summary>
    public partial class NoteControl : UserControl
    {


        public Note Note
        {
            get { return (Note)GetValue(NoteProperty); }
            set { SetValue(NoteProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NoteProperty =
            DependencyProperty.Register("Note", typeof(Note), typeof(NoteControl), new PropertyMetadata(null, SetValue));

        private static void SetValue(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
           NoteControl note = d as NoteControl;

           if (note != null)
           {
               note.TxtBlkTitle.Text = (e.NewValue as Note).Title;
               note.TxtBlkEdited.Text = (e.NewValue as Note).UpdatedTime.ToShortDateString();
               note.TxtBlkContent.Text = (e.NewValue as Note).Title;
           }
        }


        public NoteControl()
        {
            InitializeComponent();
        }
    }
}
