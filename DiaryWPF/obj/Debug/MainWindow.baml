   M S B A M L   `   `   `  ????O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	   C ?DiaryWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:DiaryWPFDiaryWPF 5   	      DiaryWPF.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   (localclr-namespace:DiaryWPF     5   	     ? Title$  Diary??5	   	   $	??350??6   $	??500??6$   .??5
      ?  ? RowDefinitions 5   
   ?? 5      $
??Auto ?6   ?? 5      $??* ?6   ?? 5      $
??Auto ?6   .+?5   
   ??  ?? Orientation$ 
Horizontal=?6   $??5q?6.   .+?5      ?? $??Select a date:??6   $??0,0,5,0q?6.   $??Center=?6?   &   System.Windows.Controls.Calendar  5      -   5          Name$ calendar??5      
 ?? Now   DisplayDate# Z 6)   6S   5      ?? 5   
   $ 
Horizontal=?6   $??2??6.   $??5q?6;   .+?5      ?? -   5        $??Delete??5      6&   ?? 5      -   5         ??Name$ Button??5      $	??Add??6%   63   5      ?? 5   
   -   5         ??Name$ 	notesList??5      $??1??6&   $??10q?63   5       5!      5"      