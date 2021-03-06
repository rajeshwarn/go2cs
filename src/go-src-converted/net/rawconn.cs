// Copyright 2017 The Go Authors. All rights reserved.
// Use of this source code is governed by a BSD-style
// license that can be found in the LICENSE file.

// package net -- go2cs converted at 2020 October 09 04:52:11 UTC
// import "net" ==> using net = go.net_package
// Original source: C:\Go\src\net\rawconn.go
using runtime = go.runtime_package;
using syscall = go.syscall_package;
using static go.builtin;
using System;

namespace go
{
    public static partial class net_package
    {
        // BUG(tmm1): On Windows, the Write method of syscall.RawConn
        // does not integrate with the runtime's network poller. It cannot
        // wait for the connection to become writeable, and does not respect
        // deadlines. If the user-provided callback returns false, the Write
        // method will fail immediately.

        // BUG(mikio): On JS and Plan 9, the Control, Read and Write
        // methods of syscall.RawConn are not implemented.
        private partial struct rawConn
        {
            public ptr<netFD> fd;
        }

        private static bool ok(this ptr<rawConn> _addr_c)
        {
            ref rawConn c = ref _addr_c.val;

            return c != null && c.fd != null;
        }

        private static error Control(this ptr<rawConn> _addr_c, Action<System.UIntPtr> f)
        {
            ref rawConn c = ref _addr_c.val;

            if (!c.ok())
            {
                return error.As(syscall.EINVAL)!;
            }

            var err = c.fd.pfd.RawControl(f);
            runtime.KeepAlive(c.fd);
            if (err != null)
            {
                err = addr(new OpError(Op:"raw-control",Net:c.fd.net,Source:nil,Addr:c.fd.laddr,Err:err));
            }

            return error.As(err)!;

        }

        private static error Read(this ptr<rawConn> _addr_c, Func<System.UIntPtr, bool> f)
        {
            ref rawConn c = ref _addr_c.val;

            if (!c.ok())
            {
                return error.As(syscall.EINVAL)!;
            }

            var err = c.fd.pfd.RawRead(f);
            runtime.KeepAlive(c.fd);
            if (err != null)
            {
                err = addr(new OpError(Op:"raw-read",Net:c.fd.net,Source:c.fd.laddr,Addr:c.fd.raddr,Err:err));
            }

            return error.As(err)!;

        }

        private static error Write(this ptr<rawConn> _addr_c, Func<System.UIntPtr, bool> f)
        {
            ref rawConn c = ref _addr_c.val;

            if (!c.ok())
            {
                return error.As(syscall.EINVAL)!;
            }

            var err = c.fd.pfd.RawWrite(f);
            runtime.KeepAlive(c.fd);
            if (err != null)
            {
                err = addr(new OpError(Op:"raw-write",Net:c.fd.net,Source:c.fd.laddr,Addr:c.fd.raddr,Err:err));
            }

            return error.As(err)!;

        }

        private static (ptr<rawConn>, error) newRawConn(ptr<netFD> _addr_fd)
        {
            ptr<rawConn> _p0 = default!;
            error _p0 = default!;
            ref netFD fd = ref _addr_fd.val;

            return (addr(new rawConn(fd:fd)), error.As(null!)!);
        }

        private partial struct rawListener
        {
            public ref rawConn rawConn => ref rawConn_val;
        }

        private static error Read(this ptr<rawListener> _addr_l, Func<System.UIntPtr, bool> _p0)
        {
            ref rawListener l = ref _addr_l.val;

            return error.As(syscall.EINVAL)!;
        }

        private static error Write(this ptr<rawListener> _addr_l, Func<System.UIntPtr, bool> _p0)
        {
            ref rawListener l = ref _addr_l.val;

            return error.As(syscall.EINVAL)!;
        }

        private static (ptr<rawListener>, error) newRawListener(ptr<netFD> _addr_fd)
        {
            ptr<rawListener> _p0 = default!;
            error _p0 = default!;
            ref netFD fd = ref _addr_fd.val;

            return (addr(new rawListener(rawConn{fd:fd})), error.As(null!)!);
        }
    }
}
