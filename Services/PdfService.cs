using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace CVServices
{
    public class PdfService
    {
        public byte[] GeneratePdf()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                Document document = new Document();
                PdfWriter writer = PdfWriter.GetInstance(document, stream);

                // Ouvrir le document
                document.Open();

                // Ajouter une page au format lettre (8.5 x 11 pouces)
                document.SetPageSize(PageSize.LETTER);

                // Créer un tableau pour la mise en page
                PdfPTable layoutTable = new PdfPTable(2);
                layoutTable.WidthPercentage = 100f;
                layoutTable.SetWidths(new float[] { 1f, 2f });

                // Colonne de gauche (aside bleu marine)
                PdfPCell asideCell = new PdfPCell();
                asideCell.BackgroundColor = BaseColor.DARK_GRAY;
                asideCell.Rowspan = 6; // Ajustez le nombre de rangées
                layoutTable.AddCell(asideCell);

                // Coordonnées
                PdfPCell coordinatesCell = new PdfPCell(new Phrase("Coordonnées", GetBoldFont()));
                coordinatesCell.Colspan = 2;
                layoutTable.AddCell(coordinatesCell);
                layoutTable.AddCell("Téléphone : 123-456-7890");
                layoutTable.AddCell("Email : john.doe@example.com");

                // Hard Skills
                PdfPCell hardSkillsCell = new PdfPCell(new Phrase("Hard Skills", GetBoldFont()));
                hardSkillsCell.Colspan = 2;
                layoutTable.AddCell(hardSkillsCell);
                // Ajoutez ici les hard skills (3 par ligne)

                // Soft Skills
                PdfPCell softSkillsCell = new PdfPCell(new Phrase("Soft Skills", GetBoldFont()));
                softSkillsCell.Colspan = 2;
                layoutTable.AddCell(softSkillsCell);
                // Ajoutez ici les soft skills (3 par ligne)

                // Langues
                PdfPCell languagesCell = new PdfPCell(new Phrase("Langues", GetBoldFont()));
                languagesCell.Colspan = 2;
                layoutTable.AddCell(languagesCell);
                // Ajoutez ici les langues

                // Colonne de droite (blanche)
                // Nom et Prénom
                PdfPCell nameCell = new PdfPCell(new Phrase("Prénom Nom", GetBoldFont()));
                nameCell.Colspan = 2;
                layoutTable.AddCell(nameCell);
                layoutTable.AddCell("Description du profil");

                // Experience
                PdfPCell experienceCell = new PdfPCell(new Phrase("Expérience", GetBoldFont()));
                experienceCell.Colspan = 2;
                layoutTable.AddCell(experienceCell);
                // Ajoutez ici les expériences professionnelles

                // Formation (Education)
                PdfPCell educationCell = new PdfPCell(new Phrase("Formation (Education)", GetBoldFont()));
                educationCell.Colspan = 2;
                layoutTable.AddCell(educationCell);
                // Ajoutez ici les formations éducatives

                // Ajouter le tableau au document
                document.Add(layoutTable);

                // Fermer le document
                document.Close();

                return stream.ToArray();
            }
        }

        private Font GetBoldFont()
        {
            Font font = new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD);
            font.Color = BaseColor.WHITE;
            return font;
        }
    }

}
