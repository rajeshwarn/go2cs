// Copyright 2010 The Go Authors. All rights reserved.
// Use of this source code is governed by a BSD-style
// license that can be found in the LICENSE file.

// package cmplx -- go2cs converted at 2020 October 09 05:07:48 UTC
// import "math/cmplx" ==> using cmplx = go.math.cmplx_package
// Original source: C:\Go\src\math\cmplx\polar.go

using static go.builtin;

namespace go {
namespace math
{
    public static partial class cmplx_package
    {
        // Polar returns the absolute value r and phase θ of x,
        // such that x = r * e**θi.
        // The phase is in the range [-Pi, Pi].
        public static (double, double) Polar(System.Numerics.Complex128 x)
        {
            double r = default;
            double θ = default;

            return (Abs(x), Phase(x));
        }
    }
}}
