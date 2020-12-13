module Views

open Giraffe
open Microsoft.AspNetCore.Http
open Giraffe.ViewEngine

let svgView (xmlNode : XmlNode) : HttpHandler =
    let bytes = RenderView.AsBytes.xmlNode xmlNode
    fun (_ : HttpFunc) (ctx : HttpContext) ->
        ctx.SetContentType "image/svg+xml; charset=utf-8"
        ctx.WriteBytesAsync bytes
