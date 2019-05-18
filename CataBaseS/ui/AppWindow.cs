using System.Linq;
using System.Text;
using Gtk;

namespace CataBaseS.ui
{
    public class AppWindow : Window
    {
        private Entry _entryText;
        private Entry _entryNumber;
        private Button _buttonSave;
        private Button _buttonClear;

        public AppWindow(string title) : base(title)
        {
            Box rootContainer = new Box(Orientation.Vertical, 8);

            rootContainer.Add(GetNumberInputBox());
            rootContainer.Add(GetTextInputBox());
            rootContainer.Add(new Separator(Orientation.Horizontal));
            rootContainer.Add(GetButtonBox());

            rootContainer.Margin = 8;

            Add(rootContainer);

            ShowAll();

            Resizable = false;

            DeleteEvent += delegate { Application.Quit(); };
        }

        private Box GetNumberInputBox()
        {
            var box = new Box(Orientation.Horizontal, 8);

            box.Add(new Label("№") {WidthChars = 5});
            box.Add(_entryNumber = new NumberEntry {InputPurpose = InputPurpose.Number, MaxLength = 12});
            _entryNumber.InputPurpose = InputPurpose.Number;
            _entryNumber.MaxLength = 12;

            return box;
        }

        private Box GetTextInputBox()
        {
            var box = new Box(Orientation.Horizontal, 8);

            box.Add(new Label("Text: ") {WidthChars = 5});
            box.Add(_entryText = new Entry {MaxLength = 255});

            return box;
        }

        private Box GetButtonBox()
        {
            var box = new ButtonBox(Orientation.Horizontal);

            _buttonClear = new LinkButton("https://www.youtube.com/watch?v=EPUVstUH22k", "Clear");
            box.Add(_buttonClear);

            _buttonSave = new Button("Save");
            box.Add(_buttonSave);

            return box;
        }
    }

    class NumberEntry : Entry
    {
        private static readonly char[] AllowedChars = new[] {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};

        protected override void OnTextInserted(string new_text, ref int position)
        {
            var sb = new StringBuilder(1, new_text.Length);
            foreach (char c in new_text)
                if (IsNum(c))
                    sb.Append(c);

            base.OnTextInserted(sb.ToString(), ref position);
        }

        private static bool IsNum(char character)
        {
            return AllowedChars.Contains(character);
        }
    }
}