important
===

this project is forked from https://github.com/am11/RectanglePacker

License: http://www.codeproject.com/info/cpol10.aspx



usage
===

1 collect some images or icons and put them in some folders, like this:

```
sprites
|-main
  |-left.arrow.png
  |-right.arrow.png
  |-global.jpg
|-misc
  |-hand.jpg
  |-icon.gif
```

2 run CssSpriteGenerator 

```
CssSpriteGenerator sprites
```

3 each sub-directory will generate an image and css file:

```
sprites
|-main
  |-left.arrow.png
  |-right.arrow.png
  |-global.jpg
|-misc
  |-hand.jpg
  |-icon.gif
|-main.png
|-main.css
|-misc.png
|-misc.css
```

and ths css file like this:

```
.main.left-arrow
{
  background-image: url( 'main.png' );
  width: ##px;
  height: ##px;
  background-position: ##px ##px;
}
```


4 enjoy it.
