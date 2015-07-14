﻿// Guids.cs
// MUST match guids.h
using System;

namespace TemplateMenuCommands
{
    static class GuidList
    {
        public const string GuidMenuCommandsPkgString = "50e56921-f7aa-47bb-9a25-4b7a8cc2600f";
        public const string GuidMenuCommandsCmdSetString = "393da428-4dec-489d-9bc7-586dd3deae24";
        public static readonly Guid GuidMenuCommandsCmdSet = new Guid(GuidMenuCommandsCmdSetString);
    };
}