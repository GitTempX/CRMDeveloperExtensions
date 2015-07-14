﻿using EnvDTE;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;
using System;

namespace WebResourceDeployer
{
    public sealed class VsHierarchyEvents : IVsHierarchyEvents
    {
        private readonly IVsHierarchy _hierarchy;
        private readonly WebResourceList _webResourceList;

        public VsHierarchyEvents(IVsHierarchy hierarchy, WebResourceList webResourcelist)
        {
            _hierarchy = hierarchy;
            _webResourceList = webResourcelist;
        }

        int IVsHierarchyEvents.OnInvalidateIcon(IntPtr hicon)
        {
            return VSConstants.S_OK;
        }

        int IVsHierarchyEvents.OnInvalidateItems(uint itemidParent)
        {
            return VSConstants.S_OK;
        }

        int IVsHierarchyEvents.OnItemAdded(uint itemidParent, uint itemidSiblingPrev, uint itemidAdded)
        {
            object itemExtObject;
            if (_hierarchy.GetProperty(itemidAdded, (int)__VSHPROPID.VSHPROPID_ExtObject, out itemExtObject) == VSConstants.S_OK)
            {
                var projectItem = itemExtObject as ProjectItem;
                if (projectItem != null)
                    _webResourceList.ProjectItemAdded(projectItem, itemidAdded);
            }
            return VSConstants.S_OK;
        }

        int IVsHierarchyEvents.OnItemDeleted(uint itemid)
        {
            object itemExtObject;
            if (_hierarchy.GetProperty(itemid, (int)__VSHPROPID.VSHPROPID_ExtObject, out itemExtObject) == VSConstants.S_OK)
            {
                var projectItem = itemExtObject as ProjectItem;
                if (projectItem != null)
                    _webResourceList.ProjectItemRemoved(projectItem, itemid);
            }
            return VSConstants.S_OK;
        }

        int IVsHierarchyEvents.OnItemsAppended(uint itemidParent)
        {
            return VSConstants.S_OK;
        }

        int IVsHierarchyEvents.OnPropertyChanged(uint itemid, int propid, uint flags)
        {
            return VSConstants.S_OK;
        }
    }
}
