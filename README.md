# PhotoSlide 

> [!WARNING]
> Repository is now archived. Running on latest version of Windows (Windows 10, 11) as of writing is not guaranteed.
> 

> [!NOTE]
> I created this back in the day during Windows 7 era(My Laptop can't run Windows 8/10, since it's only 32-bit and only got 2gb of RAM) , it was the time where Windows 10 is at it's early adoption.
> 
> This is one of my random ideas where I want to play a slideshow of images including animated GIF's which is also capable running multiple instances where each window plays different slides.
>
> _For what use?... For educational purposes, I learned structure to load/write basic file format, open files in drag and drop, basic understanding on animated GIF._ ( ͡° ͜◯ ͡°)  

<b>PhotoSlide</b> is a simple photo viewer written in C# developed for personal use, Using the Winforms default PictureBox Control, The <b>Photo Slide</b> Prototype can play basic slideshow of images(*jpg, png, animated gif*) without slide effects in window mode. Photo slide can also create a photo playlist file, think of it as something similar to an MP3 playlist, but for images. <br>
Currently, the playlist extention of PhotoSlide is a readable'txt' file.

There is source included `VistaFolderBrowserDialog` UI from [Ooki.Dialogs](http://www.ookii.org/software/dialogs/) for a user-friendly folder browser dialog and such.

<b>PhotoSlide</b> supports opening image files directly either by default or drag and drop<br>

For a looped animated GIF, it will play the GIF once and move on the next slide.

### Requirements
To *run*, you need

* .NET 3.5 (or above)

To *compile*, you need

* C# compiler, such as:
	* Visual Studio

### Development Status
* Prototype
