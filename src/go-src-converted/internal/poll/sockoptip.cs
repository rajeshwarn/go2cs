// Copyright 2011 The Go Authors. All rights reserved.
// Use of this source code is governed by a BSD-style
// license that can be found in the LICENSE file.

// +build aix darwin dragonfly freebsd linux netbsd openbsd solaris windows

// package poll -- go2cs converted at 2020 October 09 04:51:22 UTC
// import "internal/poll" ==> using poll = go.@internal.poll_package
// Original source: C:\Go\src\internal\poll\sockoptip.go
using syscall = go.syscall_package;
using static go.builtin;

namespace go {
namespace @internal
{
    public static partial class poll_package
    {
        // SetsockoptIPMreq wraps the setsockopt network call with an IPMreq argument.
        private static error SetsockoptIPMreq(this ptr<FD> _addr_fd, long level, long name, ptr<syscall.IPMreq> _addr_mreq) => func((defer, _, __) =>
        {
            ref FD fd = ref _addr_fd.val;
            ref syscall.IPMreq mreq = ref _addr_mreq.val;

            {
                var err = fd.incref();

                if (err != null)
                {
                    return error.As(err)!;
                }
            }

            defer(fd.decref());
            return error.As(syscall.SetsockoptIPMreq(fd.Sysfd, level, name, mreq))!;

        });

        // SetsockoptIPv6Mreq wraps the setsockopt network call with an IPv6Mreq argument.
        private static error SetsockoptIPv6Mreq(this ptr<FD> _addr_fd, long level, long name, ptr<syscall.IPv6Mreq> _addr_mreq) => func((defer, _, __) =>
        {
            ref FD fd = ref _addr_fd.val;
            ref syscall.IPv6Mreq mreq = ref _addr_mreq.val;

            {
                var err = fd.incref();

                if (err != null)
                {
                    return error.As(err)!;
                }

            }

            defer(fd.decref());
            return error.As(syscall.SetsockoptIPv6Mreq(fd.Sysfd, level, name, mreq))!;

        });
    }
}}
