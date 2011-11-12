﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lucene.Net.Index;
using Lucene.Net.Store;
using Lucene.Net.Util;
using NUnit.Framework;

namespace Lucene.Net.Test.Index
{
    public class TestIndexCommit : LuceneTestCase
    {
        private Directory dir;

        private class IndexCommitFirst : IndexCommit
        {
            private readonly Directory _dir;

            public IndexCommitFirst(Directory dir)
            {
                _dir = dir;
            }

            public override string GetSegmentsFileName()
            {
                return "a";
            }

            public override ICollection<string> GetFileNames()
            {
                return null;
            }

            public override void Delete()
            { }

            public override bool IsDeleted()
            {
                return false;
            }

            public override bool IsOptimized()
            {
                return false;
            }

            public override long GetVersion()
            {
                return 12;
            }

            public override long GetGeneration()
            {
                return 0;
            }

            public override IDictionary<string, string> GetUserData()
            {
                return null;
            }

            public override Directory GetDirectory()
            {
                return _dir;
            }

            public override long GetTimestamp()
            {
                return 1;
            }
        }
        private class IndexCommitSecond : IndexCommit
        {
            private readonly Directory _dir;

            public IndexCommitSecond(Directory dir)
            {
                _dir = dir;
            }

            public override string GetSegmentsFileName()
            {
                return "b";
            }

            public override ICollection<string> GetFileNames()
            {
                return null;
            }

            public override void Delete()
            { }

            public override bool IsDeleted()
            {
                return false;
            }

            public override bool IsOptimized()
            {
                return false;
            }

            public override long GetVersion()
            {
                return 12;
            }

            public override long GetGeneration()
            {
                return 0;
            }

            public override IDictionary<string, string> GetUserData()
            {
                return null;
            }

            public override Directory GetDirectory()
            {
                return _dir;
            }

            public override long GetTimestamp()
            {
                return 1;
            }
        }

        [Test]
        public void TestEqualsHashCode()
        {
            dir = new RAMDirectory();
            var ic1 = new IndexCommitFirst(dir);
            var ic2 = new IndexCommitSecond(dir);
            Assert.AreEqual(ic1, ic2);
            Assert.AreEqual(ic1.GetHashCode(), ic2.GetHashCode(), "Hash codes are not equals");
        }
    }
}