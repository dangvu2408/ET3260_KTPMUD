   M S B A M L   `   `   `  ����I  EET3260_Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ET3260_ProjectET3260_Project  5   	       ET3260_Project.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:ET3260_Project     5   	     � Title$-  'Quản lý dịch bệnh và thiên tai��5   	   $	��450��60   $	��800��6=    � Icon$( "Resources/Images/app_icon_1024.png��5	   	   .��5
      �  � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   .+�5   
   � $��0��6   .+�5      �� $'��!Resources/Images/app_banner_1.jpg��6   $��UniformToFill=�6?   $��Center=�6W   $��Center=�6t   � 5      .+�5      �� $��0��6   ��5      �� 5       �� 
StartPoint$	 0,0&�6.    �� EndPoint$	 1,0&�6?   .��5      �  � Color$ Black��6+    � Offset$ 0Q�69   � 5      $ Transparent��6+   $ 1Q�6?   5      5      �� 5       $��0��6   $
��Left=�6-   $��Center=�6H   $��20q�6c   .+�5!      �� $��HỆ THỐNG QUẢN LÝ��6    $��24(�68   
�������$
��Bold"�6Y   $+��%Resources/Fonts/#SF Pro Display Black)�6k   $��0, 10q�6�   �� 5"      $"��DỊCH BỆNH VÀ THIÊN TAI��6    $��20(�6>   
�������$��Regular"�6_   $*��$Resources/Fonts/#SF Pro Display Bold)�6t   5#      5%      5&      � 5)   
   $��1��6   .+�5*      �� $��10q�6   $��Center=�6%   .+�5+      �� $ ��ĐĂNG NHẬP HỆ THỐNG��6   $��24(�66   $��Black"�6D   
���   �$+��%Resources/Fonts/#SF Pro Display Black)�6j   $��Center=�6�   $��	0 10 0 20q�6�   �� 5-      ���#F5F4FF �� CornerRadius$ 15��6.    �� Padding$ 10q�6@   $��50��6M   $��10q�6Y   ._�5.      �  5/      �� 50      $��40 �6/   �� 51      $��* �6/   .+�54      �� $%��Resources/Images/user_black.png��6    $��Center=�6I   $��20��6d   �� 56      -   5        	 ��Name$	 un��56   "   $��1��57      
������ $��0q�59      $��Center=�5:      $��16(�5;      ���#333333$-��'Resources/Fonts/#SF Pro Display Regular)�5>      5?      5@      �� 5B      ���#F5F4FF$ 15��6.   $ 10q�6@   $��50��6M   $��10q�6Y   ._�5C      �  5D      �� 5E      $��40 �6/   �� 5F      $��* �6/   .+�5I      �� $%��Resources/Images/lock_black.png��6    $��Center=�6I   $��20��6d   G� 5K      -   5        
 G�Name$
 ps��5K   &   $��1��5L      
������ $��0q�5N      $��Center=�5O      $��16(�5P      ���#3333335R      5S      5T      �� 5W      $ 5��6   
����  �$ 2q�6=   $��0 10 0 0q�6I   $	��150��6[   ._�5X      �� -   5        $��ĐĂNG NHẬP��5X      $��16(�61   $��30��6?   
������ $��0q�6d   
�������$*��$Resources/Fonts/#SF Pro Display Bold)�6�   5Y      �� 5[      $ 5��6   
�������$ 2q�6=   $��0 10 0 0q�6I   $	��150��6[   ._�5\      �� -   5        $��
ĐĂNG KÍ��5\      $��16(�6/   $��25��6=   
������ $��0q�6b   $*��$Resources/Fonts/#SF Pro Display Bold)�6�   5]      5^      5_      5d      5e      