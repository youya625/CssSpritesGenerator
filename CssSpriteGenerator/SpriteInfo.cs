using Mapper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CssSpriteGenerator
{
  public sealed class SpriteInfo
  {

    private SpriteInfo() { }

    internal static SpriteInfo Create( MappedImageCollection mappedResult )
    {

      var info = new SpriteInfo();

      var items = mappedResult.MappedImages.Select( item => SpriteItem.Create( item, info ) ).ToArray();

      return new SpriteInfo
      {
        Size = new Size( mappedResult.Width, mappedResult.Height ),
        Items = items
      };

    }


    public Size Size { get; private set; }

    public SpriteItem[] Items { get; private set; }



    public Image GenerateSpriteImage()
    {
      var canvas = new Bitmap( Size.Width, Size.Height );
      var graphic = Graphics.FromImage( canvas );

      foreach ( var item in Items )
      {
        graphic.DrawImage( item.ImageInfo.Image, item.Rectangle );
      }

      return canvas;
    }


    public string GenerateStyleSheet( string spriteImage, string directoryName = null )
    {

      var writer = new StringWriter();

      foreach ( var item in Items )
      {

        var selector = "." + item.ImageInfo.Name;
        if ( directoryName != null )
          selector = "." + directoryName + selector;

        writer.WriteLine( selector );
        writer.WriteLine( "{" );
        writer.WriteLine( "  background-image: url('{0}');", Path.GetFileName( spriteImage ) );
        writer.WriteLine( "  background-position: {0}px {1}px;", -item.Offset.X, -item.Offset.Y );
        writer.WriteLine( "  width: {0}px;", item.ImageInfo.Width );
        writer.WriteLine( "  height: {0}px;", item.ImageInfo.Height );
        writer.WriteLine( "}" );
      }

      return writer.ToString();
    }



    public void CreateSpriteTo( string directory, string name, string directoryName = null )
    {
      Directory.CreateDirectory( directory );

      var imagePath = Path.Combine( directory, name + ".png" );
      var cssPath = Path.Combine( directory, name + ".css" );
      File.Delete( imagePath );
      File.Delete( cssPath );


      GenerateSpriteImage().Save( imagePath );
      File.WriteAllText( cssPath, GenerateStyleSheet( Path.GetFileName( imagePath ), directoryName ) );

    }



  }
}
