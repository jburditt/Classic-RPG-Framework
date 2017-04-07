﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tIDE.Commands
{
    internal abstract class Command
    {
        protected string m_description;

        public abstract void Do();
        public abstract void Undo();

        public override string ToString()
        {
            return m_description;
        }

        public virtual string Description
        {
            get { return m_description; }
        }
    }
}
