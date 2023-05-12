using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms.Design;

namespace Rstd.Controls.ContainerListViews.Design
{

	public class ContainerListViewDesigner : ControlDesigner
	{


		private ContainerListView ListView
		{
			get
			{
				return this.Control as ContainerListView;
			}
		}



		public override ICollection AssociatedComponents
		{
			get
			{
				return this.ListView.Columns;
			}
		}



		public override DesignerVerbCollection Verbs
		{
			get
			{
				DesignerVerb value = new DesignerVerb("ListView Default", new EventHandler(this.DefaultListView));
				DesignerVerb value2 = new DesignerVerb("TreeView Default", new EventHandler(this.DefaultTreeView));
				return new DesignerVerbCollection
				{
					value,
					value2
				};
			}
		}


		protected override void PostFilterProperties(IDictionary properties)
		{
			properties.Remove("Text");
			base.PostFilterProperties(properties);
		}


		private void DefaultListView(object sender, EventArgs e)
		{
			this.SetTreeProperties(false);
		}


		private void DefaultTreeView(object sender, EventArgs e)
		{
			this.SetTreeProperties(true);
		}


		private void SetTreeProperties(bool value)
		{
			IDesignerHost designerHost = (IDesignerHost)this.GetService(typeof(IDesignerHost));
			if (designerHost != null)
			{
				DesignerTransaction designerTransaction = designerHost.CreateTransaction("Set Default Properties");
				PropertyDescriptor member = TypeDescriptor.GetProperties(base.Component)["ShowPlusMinus"];
				PropertyDescriptor member2 = TypeDescriptor.GetProperties(base.Component)["ShowTreeLines"];
				PropertyDescriptor member3 = TypeDescriptor.GetProperties(base.Component)["ShowRootTreeLines"];
				base.RaiseComponentChanging(member);
				base.RaiseComponentChanging(member2);
				base.RaiseComponentChanging(member3);
				this.ListView.ShowPlusMinus = value;
				this.ListView.ShowTreeLines = value;
				this.ListView.ShowRootTreeLines = value;
				base.RaiseComponentChanged(member, null, null);
				base.RaiseComponentChanged(member2, null, null);
				base.RaiseComponentChanged(member3, null, null);
				designerTransaction.Commit();
			}
		}
	}
}
