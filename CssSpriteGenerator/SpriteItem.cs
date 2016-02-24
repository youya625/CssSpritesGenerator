using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapper;

namespace CssSpriteGenerator
{


  /// <summary>
  /// sprite image item
  /// </summary>
  public sealed class SpriteItem
  {

    private SpriteItem( ImageInfo image, Point offset, SpriteInfo sprite )
    {
      ImageInfo = image;
      Offset = offset;
      SpriteInfo = sprite;
    }

    internal static SpriteItem Create( IMappedImageInfo item, SpriteInfo sprite )
    {
      return new SpriteItem( (ImageInfo) item.ImageInfo, new Point( item.X, item.Y ), sprite );
    }

    public ImageInfo ImageInfo { get; private set; }

    public Point Offset { get; private set; }

    public SpriteInfo SpriteInfo { get; private set; }
    public Rectangle Rectangle { get { return new Rectangle( Offset, ImageInfo.Size ); } }
  }
}
