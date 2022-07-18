using EllieMae.Encompass.Licensing;
using System;
using Session = EllieMae.Encompass.Client.Session;


namespace ICE.Commander
{
    public class RemoteSession
    {
        public static Session Connect(ElieConnections con)
        {
			if (GetLicense(con))
			{
				Session session = new Session();
				session.Start(con.sdkPath, con.sdkUser, con.sdkPassword);
				return session;
			}
			else
			    return null;
        }

		protected static bool GetLicense(ElieConnections con)
        {
			try
			{
				LicenseManager mngr = new LicenseManager();

				if (!mngr.LicenseKeyExists() | mngr.ValidateLicense(true) == false)
				{
					try
					{
						mngr.GenerateLicense(con.licenseKey);
						return true;
					}
					catch (Exception ex)
					{

						return false;
					}
				}
				return true;
			}
			catch (Exception e)
            {
				var i = e.Message;
				return false;
            }
		}
    }
}
