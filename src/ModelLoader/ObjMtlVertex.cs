using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibGC.ModelLoader
{
    /// <summary>
    /// Represents each vertex reference in a .OBJ face declaration.
    /// </summary>
    public class ObjMtlVertex
    {
        /// <summary>
        /// The position of the vertex (X,Y,Z,W).
        /// </summary>
        public Vector4 Position { get; set; }

        /// <summary>
        /// The vertex normal of the vertex (X,Y,Z), or null if the vertex doesn't have a texture coordinate.
        /// </summary>
        public Vector3? Normal { get; set; }

        /// <summary>
        /// The texture coordinate of the vertex (U,V,W), or null if the vertex doesn't have a texture coordinate.
        /// </summary>
        public Vector3? TexCoord { get; set; }

        /// <summary>
        /// Create a new vertex reference in a .OBJ face declaration.
        /// </summary>
        /// <param name="position">The position of the vertex (X,Y,Z,W).</param>
        /// <param name="normal">The vertex normal of the vertex (X,Y,Z), or null if the vertex doesn't have a texture coordinate.</param>
        /// <param name="texCoord">The texture coordinate of the vertex (U,V,W), or null if the vertex doesn't have a texture coordinate.</param>
        public ObjMtlVertex(Vector4 position, Vector3? normal, Vector3? texCoord)
        {
            this.Position = position;
            this.Normal = normal;
            this.TexCoord = texCoord;
        }
    }
}
