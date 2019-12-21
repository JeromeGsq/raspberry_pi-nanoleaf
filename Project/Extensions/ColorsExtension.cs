namespace System.Drawing
{
    public static class Colors
    {
        public static Color ClampedColor(int r, int g, int b, int a = 255)
        {
            return Color.FromArgb(
                      Math.Clamp(r, 0, 255),
                      Math.Clamp(g, 0, 255),
                      Math.Clamp(b, 0, 255),
                      Math.Clamp(a, 0, 255)
                    );
        }
    }
}
