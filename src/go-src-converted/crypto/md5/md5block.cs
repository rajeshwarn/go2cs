// Copyright 2013 The Go Authors. All rights reserved.
// Use of this source code is governed by a BSD-style
// license that can be found in the LICENSE file.

// Code generated by go run gen.go -output md5block.go; DO NOT EDIT.

// package md5 -- go2cs converted at 2020 October 09 04:54:36 UTC
// import "crypto/md5" ==> using md5 = go.crypto.md5_package
// Original source: C:\Go\src\crypto\md5\md5block.go
using binary = go.encoding.binary_package;
using bits = go.math.bits_package;
using static go.builtin;

namespace go {
namespace crypto
{
    public static partial class md5_package
    {
        private static void blockGeneric(ptr<digest> _addr_dig, slice<byte> p)
        {
            ref digest dig = ref _addr_dig.val;
 
            // load state
            var a = dig.s[0L];
            var b = dig.s[1L];
            var c = dig.s[2L];
            var d = dig.s[3L];

            {
                long i = 0L;

                while (i <= len(p) - BlockSize)
                { 
                    // eliminate bounds checks on p
                    var q = p[i..];
                    q = q.slice(-1, BlockSize, BlockSize); 

                    // save current state
                    var aa = a;
                    var bb = b;
                    var cc = c;
                    var dd = d; 

                    // load input block
                    var x0 = binary.LittleEndian.Uint32(q[4L * 0x0UL..]);
                    var x1 = binary.LittleEndian.Uint32(q[4L * 0x1UL..]);
                    var x2 = binary.LittleEndian.Uint32(q[4L * 0x2UL..]);
                    var x3 = binary.LittleEndian.Uint32(q[4L * 0x3UL..]);
                    var x4 = binary.LittleEndian.Uint32(q[4L * 0x4UL..]);
                    var x5 = binary.LittleEndian.Uint32(q[4L * 0x5UL..]);
                    var x6 = binary.LittleEndian.Uint32(q[4L * 0x6UL..]);
                    var x7 = binary.LittleEndian.Uint32(q[4L * 0x7UL..]);
                    var x8 = binary.LittleEndian.Uint32(q[4L * 0x8UL..]);
                    var x9 = binary.LittleEndian.Uint32(q[4L * 0x9UL..]);
                    var xa = binary.LittleEndian.Uint32(q[4L * 0xaUL..]);
                    var xb = binary.LittleEndian.Uint32(q[4L * 0xbUL..]);
                    var xc = binary.LittleEndian.Uint32(q[4L * 0xcUL..]);
                    var xd = binary.LittleEndian.Uint32(q[4L * 0xdUL..]);
                    var xe = binary.LittleEndian.Uint32(q[4L * 0xeUL..]);
                    var xf = binary.LittleEndian.Uint32(q[4L * 0xfUL..]); 

                    // round 1
                    a = b + bits.RotateLeft32((((c ^ d) & b) ^ d) + a + x0 + 0xd76aa478UL, 7L);
                    d = a + bits.RotateLeft32((((b ^ c) & a) ^ c) + d + x1 + 0xe8c7b756UL, 12L);
                    c = d + bits.RotateLeft32((((a ^ b) & d) ^ b) + c + x2 + 0x242070dbUL, 17L);
                    b = c + bits.RotateLeft32((((d ^ a) & c) ^ a) + b + x3 + 0xc1bdceeeUL, 22L);
                    a = b + bits.RotateLeft32((((c ^ d) & b) ^ d) + a + x4 + 0xf57c0fafUL, 7L);
                    d = a + bits.RotateLeft32((((b ^ c) & a) ^ c) + d + x5 + 0x4787c62aUL, 12L);
                    c = d + bits.RotateLeft32((((a ^ b) & d) ^ b) + c + x6 + 0xa8304613UL, 17L);
                    b = c + bits.RotateLeft32((((d ^ a) & c) ^ a) + b + x7 + 0xfd469501UL, 22L);
                    a = b + bits.RotateLeft32((((c ^ d) & b) ^ d) + a + x8 + 0x698098d8UL, 7L);
                    d = a + bits.RotateLeft32((((b ^ c) & a) ^ c) + d + x9 + 0x8b44f7afUL, 12L);
                    c = d + bits.RotateLeft32((((a ^ b) & d) ^ b) + c + xa + 0xffff5bb1UL, 17L);
                    b = c + bits.RotateLeft32((((d ^ a) & c) ^ a) + b + xb + 0x895cd7beUL, 22L);
                    a = b + bits.RotateLeft32((((c ^ d) & b) ^ d) + a + xc + 0x6b901122UL, 7L);
                    d = a + bits.RotateLeft32((((b ^ c) & a) ^ c) + d + xd + 0xfd987193UL, 12L);
                    c = d + bits.RotateLeft32((((a ^ b) & d) ^ b) + c + xe + 0xa679438eUL, 17L);
                    b = c + bits.RotateLeft32((((d ^ a) & c) ^ a) + b + xf + 0x49b40821UL, 22L); 

                    // round 2
                    a = b + bits.RotateLeft32((((b ^ c) & d) ^ c) + a + x1 + 0xf61e2562UL, 5L);
                    d = a + bits.RotateLeft32((((a ^ b) & c) ^ b) + d + x6 + 0xc040b340UL, 9L);
                    c = d + bits.RotateLeft32((((d ^ a) & b) ^ a) + c + xb + 0x265e5a51UL, 14L);
                    b = c + bits.RotateLeft32((((c ^ d) & a) ^ d) + b + x0 + 0xe9b6c7aaUL, 20L);
                    a = b + bits.RotateLeft32((((b ^ c) & d) ^ c) + a + x5 + 0xd62f105dUL, 5L);
                    d = a + bits.RotateLeft32((((a ^ b) & c) ^ b) + d + xa + 0x02441453UL, 9L);
                    c = d + bits.RotateLeft32((((d ^ a) & b) ^ a) + c + xf + 0xd8a1e681UL, 14L);
                    b = c + bits.RotateLeft32((((c ^ d) & a) ^ d) + b + x4 + 0xe7d3fbc8UL, 20L);
                    a = b + bits.RotateLeft32((((b ^ c) & d) ^ c) + a + x9 + 0x21e1cde6UL, 5L);
                    d = a + bits.RotateLeft32((((a ^ b) & c) ^ b) + d + xe + 0xc33707d6UL, 9L);
                    c = d + bits.RotateLeft32((((d ^ a) & b) ^ a) + c + x3 + 0xf4d50d87UL, 14L);
                    b = c + bits.RotateLeft32((((c ^ d) & a) ^ d) + b + x8 + 0x455a14edUL, 20L);
                    a = b + bits.RotateLeft32((((b ^ c) & d) ^ c) + a + xd + 0xa9e3e905UL, 5L);
                    d = a + bits.RotateLeft32((((a ^ b) & c) ^ b) + d + x2 + 0xfcefa3f8UL, 9L);
                    c = d + bits.RotateLeft32((((d ^ a) & b) ^ a) + c + x7 + 0x676f02d9UL, 14L);
                    b = c + bits.RotateLeft32((((c ^ d) & a) ^ d) + b + xc + 0x8d2a4c8aUL, 20L); 

                    // round 3
                    a = b + bits.RotateLeft32((b ^ c ^ d) + a + x5 + 0xfffa3942UL, 4L);
                    d = a + bits.RotateLeft32((a ^ b ^ c) + d + x8 + 0x8771f681UL, 11L);
                    c = d + bits.RotateLeft32((d ^ a ^ b) + c + xb + 0x6d9d6122UL, 16L);
                    b = c + bits.RotateLeft32((c ^ d ^ a) + b + xe + 0xfde5380cUL, 23L);
                    a = b + bits.RotateLeft32((b ^ c ^ d) + a + x1 + 0xa4beea44UL, 4L);
                    d = a + bits.RotateLeft32((a ^ b ^ c) + d + x4 + 0x4bdecfa9UL, 11L);
                    c = d + bits.RotateLeft32((d ^ a ^ b) + c + x7 + 0xf6bb4b60UL, 16L);
                    b = c + bits.RotateLeft32((c ^ d ^ a) + b + xa + 0xbebfbc70UL, 23L);
                    a = b + bits.RotateLeft32((b ^ c ^ d) + a + xd + 0x289b7ec6UL, 4L);
                    d = a + bits.RotateLeft32((a ^ b ^ c) + d + x0 + 0xeaa127faUL, 11L);
                    c = d + bits.RotateLeft32((d ^ a ^ b) + c + x3 + 0xd4ef3085UL, 16L);
                    b = c + bits.RotateLeft32((c ^ d ^ a) + b + x6 + 0x04881d05UL, 23L);
                    a = b + bits.RotateLeft32((b ^ c ^ d) + a + x9 + 0xd9d4d039UL, 4L);
                    d = a + bits.RotateLeft32((a ^ b ^ c) + d + xc + 0xe6db99e5UL, 11L);
                    c = d + bits.RotateLeft32((d ^ a ^ b) + c + xf + 0x1fa27cf8UL, 16L);
                    b = c + bits.RotateLeft32((c ^ d ^ a) + b + x2 + 0xc4ac5665UL, 23L); 

                    // round 4
                    a = b + bits.RotateLeft32((c ^ (b | ~d)) + a + x0 + 0xf4292244UL, 6L);
                    d = a + bits.RotateLeft32((b ^ (a | ~c)) + d + x7 + 0x432aff97UL, 10L);
                    c = d + bits.RotateLeft32((a ^ (d | ~b)) + c + xe + 0xab9423a7UL, 15L);
                    b = c + bits.RotateLeft32((d ^ (c | ~a)) + b + x5 + 0xfc93a039UL, 21L);
                    a = b + bits.RotateLeft32((c ^ (b | ~d)) + a + xc + 0x655b59c3UL, 6L);
                    d = a + bits.RotateLeft32((b ^ (a | ~c)) + d + x3 + 0x8f0ccc92UL, 10L);
                    c = d + bits.RotateLeft32((a ^ (d | ~b)) + c + xa + 0xffeff47dUL, 15L);
                    b = c + bits.RotateLeft32((d ^ (c | ~a)) + b + x1 + 0x85845dd1UL, 21L);
                    a = b + bits.RotateLeft32((c ^ (b | ~d)) + a + x8 + 0x6fa87e4fUL, 6L);
                    d = a + bits.RotateLeft32((b ^ (a | ~c)) + d + xf + 0xfe2ce6e0UL, 10L);
                    c = d + bits.RotateLeft32((a ^ (d | ~b)) + c + x6 + 0xa3014314UL, 15L);
                    b = c + bits.RotateLeft32((d ^ (c | ~a)) + b + xd + 0x4e0811a1UL, 21L);
                    a = b + bits.RotateLeft32((c ^ (b | ~d)) + a + x4 + 0xf7537e82UL, 6L);
                    d = a + bits.RotateLeft32((b ^ (a | ~c)) + d + xb + 0xbd3af235UL, 10L);
                    c = d + bits.RotateLeft32((a ^ (d | ~b)) + c + x2 + 0x2ad7d2bbUL, 15L);
                    b = c + bits.RotateLeft32((d ^ (c | ~a)) + b + x9 + 0xeb86d391UL, 21L); 

                    // add saved state
                    a += aa;
                    b += bb;
                    c += cc;
                    d += dd;
                    i += BlockSize;
                }
            } 

            // save state
            dig.s[0L] = a;
            dig.s[1L] = b;
            dig.s[2L] = c;
            dig.s[3L] = d;

        }
    }
}}
