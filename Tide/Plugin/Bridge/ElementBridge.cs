﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using tIDE.Plugin.Interface;

namespace tIDE.Plugin.Bridge
{
    internal abstract class ElementBridge: IElement
    {
		private bool m_readOnly;

        internal ElementBridge(bool readOnly)
        {
            m_readOnly = readOnly;
        }

        protected void VerifyWriteAccess()
        {
            if (m_readOnly)
                throw new Exception(
                    "No changes allowed to read-only interface element");
        }

        public bool ReadOnly
        {
            get { return m_readOnly; }
        }
    }
}
