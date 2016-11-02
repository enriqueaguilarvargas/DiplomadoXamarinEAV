package md57e12d916b826a297e8c3f14cdfc770dc;


public class VistaCapital
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("AbsoluteLayout.VistaCapital, AbsoluteLayout, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", VistaCapital.class, __md_methods);
	}


	public VistaCapital () throws java.lang.Throwable
	{
		super ();
		if (getClass () == VistaCapital.class)
			mono.android.TypeManager.Activate ("AbsoluteLayout.VistaCapital, AbsoluteLayout, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
