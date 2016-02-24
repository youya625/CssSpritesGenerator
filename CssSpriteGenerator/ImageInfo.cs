using Mapper;
using System.Drawing;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace CssSpriteGenerator
{
  public class ImageInfo : IImageInfo
  {
    private ImageInfo( Image image, string name )
    {

      Image = image;
      Name = name;

    }



    public Image Image
    {
      get; private set;
    }


    public string Name
    {
      get; private set;
    }


    public static ImageInfo Create( string path )
    {
      try
      {
        var image = Bitmap.FromFile( path );
        return new ImageInfo( image, Regex.Replace( Path.GetFileNameWithoutExtension( path ), @"\W", "-" ) );
      }
      catch
      {
        return null;
      }
    }


    public int Height
    {
      get
      {
        return Image.Height;
      }
    }

    public int Width
    {
      get
      {
        return Image.Width;
      }
    }

    public Size Size { get { return new Size( Width, Height ); } }
  }
}