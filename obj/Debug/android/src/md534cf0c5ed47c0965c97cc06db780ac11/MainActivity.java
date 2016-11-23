package md534cf0c5ed47c0965c97cc06db780ac11;


public class MainActivity
	extends android.support.v7.app.AppCompatActivity
	implements
		mono.android.IGCUserPeer,
		android.view.View.OnClickListener,
		com.felipecsl.gifimageview.library.GifImageView.OnFrameAvailableListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onClick:(Landroid/view/View;)V:GetOnClick_Landroid_view_View_Handler:Android.Views.View/IOnClickListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_onFrameAvailable:(Landroid/graphics/Bitmap;)Landroid/graphics/Bitmap;:GetOnFrameAvailable_Landroid_graphics_Bitmap_Handler:Felipecsl.GifImageViewLibrary.GifImageView/IOnFrameAvailableListenerInvoker, Refractored.GifImageView\n" +
			"";
		mono.android.Runtime.register ("GIFImageView.MainActivity, GIFImageView, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MainActivity.class, __md_methods);
	}


	public MainActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == MainActivity.class)
			mono.android.TypeManager.Activate ("GIFImageView.MainActivity, GIFImageView, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public void onClick (android.view.View p0)
	{
		n_onClick (p0);
	}

	private native void n_onClick (android.view.View p0);


	public android.graphics.Bitmap onFrameAvailable (android.graphics.Bitmap p0)
	{
		return n_onFrameAvailable (p0);
	}

	private native android.graphics.Bitmap n_onFrameAvailable (android.graphics.Bitmap p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
