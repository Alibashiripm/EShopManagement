using EShopManagement.WebMVC.Exceptions;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace EShopManagement.WebMVC.Tools
{
    public static class ImageSaver
    {
     
        public async static Task<string>  SaveImage(IFormFile image,string path,string thumbPath)
        {
            // Check if image is provided and is valid
            if (image != null && image.IsImage())
            {
                // Generate unique image name
              string  imageName = GenerateUniqCode() + Path.GetExtension(image.FileName);

                // Save image to file system
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), path, imageName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }

                // Resize image
                string generateThumbPath = Path.Combine(Directory.GetCurrentDirectory(), thumbPath, imageName);
            
                  Image_resize(imagePath, generateThumbPath, 250);
                return imageName;
            }
            else
            {
                throw new ImageNotUploadedException();
            }
         }
        private static bool IsImage(this IFormFile file)
        {
            try
            {
                var img = System.Drawing.Image.FromStream(file.OpenReadStream());
                return true;
            }
            catch
            {
                return false;
            }
        }
        private static void Image_resize(string input_Image_Path, string output_Image_Path, int new_Width)
        {

            const long quality = 50L;

            Bitmap source_Bitmap = new Bitmap(input_Image_Path);



            double dblWidth_origial = source_Bitmap.Width;

            double dblHeigth_origial = source_Bitmap.Height;

            double relation_heigth_width = dblHeigth_origial / dblWidth_origial;

            int new_Height = (int)(new_Width * relation_heigth_width);



            //< create Empty Drawarea >

            var new_DrawArea = new Bitmap(new_Width, new_Height);

            //</ create Empty Drawarea >



            using (var graphic_of_DrawArea = Graphics.FromImage(new_DrawArea))
            {

                //< setup >

                graphic_of_DrawArea.CompositingQuality = CompositingQuality.HighSpeed;

                graphic_of_DrawArea.InterpolationMode = InterpolationMode.HighQualityBicubic;

                graphic_of_DrawArea.CompositingMode = CompositingMode.SourceCopy;

                //</ setup >



                //< draw into placeholder >

                //*imports the image into the drawarea

                graphic_of_DrawArea.DrawImage(source_Bitmap, 0, 0, new_Width, new_Height);

                //</ draw into placeholder >



                //--< Output as .Jpg >--

                using (var output = System.IO.File.Open(output_Image_Path, FileMode.Create))

                {

                    //< setup jpg >

                    var qualityParamId = System.Drawing.Imaging.Encoder.Quality;

                    var encoderParameters = new EncoderParameters(1);

                    encoderParameters.Param[0] = new EncoderParameter(qualityParamId, quality);

                    //</ setup jpg >



                    //< save Bitmap as Jpg >

                    var codec = ImageCodecInfo.GetImageDecoders().FirstOrDefault(c => c.FormatID == ImageFormat.Jpeg.Guid);

                    new_DrawArea.Save(output, codec, encoderParameters);

                    //resized_Bitmap.Dispose ();

                    output.Close();

                    //</ save Bitmap as Jpg >

                }

                //--</ Output as .Jpg >--

                graphic_of_DrawArea.Dispose();

            }

            source_Bitmap.Dispose();

            //---------------</ Image_resize() >---------------

        }
        private static string GenerateUniqCode()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }

    }
}
