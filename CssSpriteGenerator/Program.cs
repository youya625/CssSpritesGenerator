using Mapper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CssSpriteGenerator
{
  class Program
  {
    static void Main( string[] args )
    {

      var directory = Environment.CurrentDirectory;
      if ( args.Length >= 1 )
        directory = args[0];


      var directories = Directory.EnumerateDirectories( directory, "*", SearchOption.AllDirectories );

      foreach ( var item in directories )
      {
        var sprite = CreateSprite( item );
        if ( sprite == null )
          continue;



        var directoryName = Regex.Replace( item.Substring( directory.Length + 1 ), @"\W", "-" );

        sprite.CreateSpriteTo( directory, directoryName, directoryName );
      }

    }

    private static SpriteInfo CreateSprite( string path )
    {

      var images = Directory.EnumerateFiles( path, "*" )
        .Select( filepath => ImageInfo.Create( filepath ) )
        .Where( item => item != null ).ToArray();

      if ( images.Any() == false )
        return null;



      var mapper = new MapperOptimalEfficiency<MappedImageCollection>( new Canvas() );
      var sprite = mapper.Mapping( images );

      return SpriteInfo.Create( sprite );

    }
  }
}
