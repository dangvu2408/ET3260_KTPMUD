   M S B A M L   `   `   `  ����I  EET3260_Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:ET3260_Project.ViewsET3260_Project.Views  5   	   ,    &ET3260_Project.Views.displayListofUser   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:ET3260_Project.Views     5   	     � Title$  Truy vấn người dùng��5   	   $	��375��6%   $	��750��62   .��5	      � .+�5
   
   �� .+�5      �� $��Danh sách người dùng��6   
���   �$��	10 0 10 0q�6F   &   System.Windows.Controls.DataGrid  5      -   5          Name$ dataGrid��5         AutoGenerateColumns$ False��5         HeadersVisibility$ Column=�5         CanUserAddRows$ False��5         	RowHeight$ 40Q�5       �� AlternationCount$ 2��5         AlternatingRowBackground �#F3F4F6$��0q�5         GridLinesVisibility$ 
Horizontal=�5      $��10q�5      	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 ID��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *ID+6L     5      $
 Email��6)   $	 200 6R    68   �� *email+6R     5      $
 Mật khẩu��6)   $	 150 6X    6;   �� *
password+6X     5"      $
 Tên đầy đủ��6)   $	 200 6Z    6=   �� *
fullname+6Z     5%      $
 Phân quyền��6)   $	 120 6b    6=   �� *role_description+6b   5(      �� 5.       �� CornerRadius$ 5��6   
����  � �� Padding$ 2q�69   $��10q�6E   ._�5/      �� -   5        $��Đóng��5/      $��25��6(   
������ $��0q�6M   
�������6t   50      52      53      54      