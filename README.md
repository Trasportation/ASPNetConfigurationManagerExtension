<h2>
ASP.Net Configuration Manager Extension 
</h2>

<p><strong>Project Description</strong><br />In ASP.net site use single web.config for all servers (dev, test, prod, etc), simple add this Extension class to read Settings or ConnectionString.<br />Very simple.<br /><br /><strong>BEFORE</strong><br /><br />Web.config</p>
<pre>  &lt;appSettings&gt;
    &lt;add key="mykey" value="myvalue" /&gt;
  &lt;/appSettings&gt;
</pre>
<p>Code</p>
<pre>var res = System.Configuration.ConfigurationManager.AppSettings["mykey"];
</pre>
<p><br />Result: <strong>myvalue</strong><br /><br /><strong>AFTER</strong><br /><br />Web.config</p>
<pre>  &lt;appSettings&gt;
    &lt;add key="[localhost]mykey" value="myvalue in localhost" /&gt;
    &lt;add key="mykey" value="myvalue" /&gt;
  &lt;/appSettings&gt;
</pre>
<p>Code</p>
<pre>var res = System.Configuration.ConfigurationManagerEx.AppSettings["mykey"];
</pre>
<p><br /><br />Result from localhost: <strong>myvalue in localhost</strong><br />Result from other machine (with default value): <strong>myvalue</strong><br /><br /><strong>New configuration manager objects</strong>:<br /><br /><strong>System.Configuration.<em>ConfigurationManagerEx</em>.AppSettings</strong><br /><strong>System.Configuration.<em>ConfigurationManagerEx</em>.ConnectionStrings</strong><br /><br />How to modify web.config?<br /><br /></p>
<pre>&lt;appSettings&gt;
     &lt;add key="[&lt;server_url_lower_case&gt;]mykey" value="myvalue in localhost" /&gt;
&lt;/appSettings&gt;
</pre>
