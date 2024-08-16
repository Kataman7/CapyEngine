using Raylib_CsLo;

namespace CapyEngine.EntityNode.GuiNode
{
    public class Button : Entity
    {
        private String text;
        private Color backgroundColor;
        private Color hoveredColor;
        private Color fontColor;
        private int fontSize;
        private Font font = new Font();
        private int padding;
        private Cursor cursor;

        private Action ?onClic;

        public Button(int x, int y, String text, Cursor cursor) : base(x, y, text.Length / 2, 2, 1)
        {
            this.text = text;
            hoveredColor = Raylib.DARKGRAY;
            fontColor = Raylib.WHITE;
            fontSize = 1;
            backgroundColor = Raylib.BLACK;
            padding = 0;
            this.cursor = cursor;
        }

        public void SetAction(Action action) { onClic = action; }

        public void SetFontSize(int size) { fontSize = size; }

        public void SetBackgroundColor(Color color) { backgroundColor = color; }

        public void SetHoveredBackgroundColor(Color color) { hoveredColor = color; }

        public void SetFontColor(Color color) { fontColor = color; }

        public void SetWidth(int width) { hitBox.width = width; }

        public void SetHeight(int height) { hitBox.height = height; }

        public void SetPadding(int padding) {
            this.padding = padding;
            this.hitBox.width += padding;
            this.hitBox.height += padding;
        }

        public override void Draw()
        {
            base.Draw();
            Raylib.DrawText(text, hitBox.x + padding, hitBox.y + padding, fontSize, fontColor);
        }

        override public void Update()
        {
            if (Raylib.CheckCollisionRecs(hitBox, cursor.hitBox))
            {
                hoverEvent();
                if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
                {
                    clicEvent();
                }
            }
            else
            {
                passifEvent();
            }
        }

        public void clicEvent()
        {
            onClic?.Invoke();
        }

        public void hoverEvent()
        {
            base.hitBoxColor = hoveredColor;
        }

        public void passifEvent()
        {
            base.hitBoxColor = Raylib.BLACK;
        }
    }
}
