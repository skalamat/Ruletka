namespace Ruletka;

/// <summary>
/// Rysuje koło ruletki na płótnie GraphicsView.
/// 37 sektorów: 1 zielony (0) + 18 czerwonych + 18 czarnych – bez numerów.
/// </summary>
public class RouletteWheelDrawable : IDrawable
{
    // Kolejność kolorów sektorów (europejska ruletka)
    // 0 = zielony, 1 = czerwony, 2 = czarny
    private static readonly int[] SectorColors =
    {
        0, 2, 1, 2, 1, 2, 1, 2, 1, 2,
        1, 2, 1, 2, 1, 2, 1, 2, 1, 2,
        1, 2, 1, 2, 1, 2, 1, 2, 1, 2,
        1, 2, 1, 2, 1, 2, 1
    };

    private const int TotalSectors = 37;
    private const float SectorAngle = 360f / TotalSectors; // ≈ 9.73°

    // Bieżący kąt obrotu koła – ustawiany przez animację w MainPage
    public float RotationAngle { get; set; } = 0f;

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        float cx = dirtyRect.Width / 2f;
        float cy = dirtyRect.Height / 2f;
        float outerRadius = Math.Min(cx, cy) * 0.96f;
        float innerRadius = outerRadius * 0.18f;
        float rimWidth = outerRadius * 0.08f;
        float dividerWidth = outerRadius * 0.012f;

        canvas.SaveState();
        canvas.Translate(cx, cy);
        canvas.Rotate(RotationAngle);

        // ── 1. Zewnętrzna obręcz ─────────────────────────────────────────────
        canvas.FillColor = Color.FromArgb("#2C1A0E");
        canvas.FillCircle(0, 0, outerRadius);

        // ── 2. Sektory ───────────────────────────────────────────────────────
        for (int i = 0; i < TotalSectors; i++)
        {
            float startAngle = i * SectorAngle - 90f;

            Color fill = SectorColors[i] switch
            {
                0 => Color.FromArgb("#006400"),  // zielony
                1 => Color.FromArgb("#C0392B"),  // czerwony
                _ => Color.FromArgb("#1A1A1A"),  // czarny
            };

            float r = outerRadius - rimWidth;
            var path = new PathF();
            path.MoveTo(0, 0);
            path.AddArc(-r, -r, r, r, startAngle, startAngle + SectorAngle, false);
            path.LineTo(0, 0);
            path.Close();

            canvas.FillColor = fill;
            canvas.FillPath(path);
        }

        // ── 3. Dekoracyjne pierścienie ───────────────────────────────────────
        float deco = outerRadius - rimWidth;
        canvas.StrokeColor = Color.FromArgb("#D4AF37");
        canvas.StrokeSize = outerRadius * 0.025f;
        canvas.DrawCircle(0, 0, deco);

        // ── 4. Środkowy krąg (zero) ──────────────────────────────────────────
        canvas.FillColor = Color.FromArgb("#005500");
        canvas.FillCircle(0, 0, innerRadius);

        canvas.StrokeColor = Color.FromArgb("#D4AF37");
        canvas.StrokeSize = outerRadius * 0.018f;
        canvas.DrawCircle(0, 0, innerRadius);

        canvas.RestoreState();
    }
}