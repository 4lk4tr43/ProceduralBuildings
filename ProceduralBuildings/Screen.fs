module Screen

open System.Drawing

type Canvas(width:double, height:double) =
        
    let Size = width, height

    member this.ToAbsolute x y = System.Math.Round(x * fst Size), System.Math.Round(y * snd Size)
    member this.ToRelative x y = double(x) / fst Size, double(y) / snd Size

    member this.ToAbsolutes a = a |> Array.map(fun e -> int(fst e * fst Size), int(snd e * snd Size))
    member this.ToRelatives a = a |> Array.map(fun e -> fst e / fst Size, snd e / snd Size)


open System.Windows.Forms

type PaintForm(width:double, height:double) as this =
    inherit Form() 

    let initialize = 
        this.ClientSize <- new System.Drawing.Size(int(width), int(height))
        this.Load.Add(fun e -> this.ImproveDisplay)

    member this.Canvas = new Canvas(width, height)

    member this.ImproveDisplay =         
        this.SetStyle(System.Windows.Forms.ControlStyles.UserPaint ||| 
                      System.Windows.Forms.ControlStyles.AllPaintingInWmPaint ||| 
                      System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer, 
                      true)
        this.DoubleBuffered <- true