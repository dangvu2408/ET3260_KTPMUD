   M S B A M L   `   `   `  ����I  EET3260_Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:ET3260_Project.ViewsET3260_Project.Views  5   	       ET3260_Project.Views.Home   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:ET3260_Project.Views     5   	     � Title$4  .Quản lý dịch bệnh và thiên tai - Home��5   	   $	��600��67   $
��1200��6D    � Icon$) #/Resources/Images/app_icon_1024.png��5	   	   .��5
      �  � ColumnDefinitions 5   
   �� 5      $
��793* �6   �� 5      $��7* �6   .+�5   
   ]� $��2��6   .+�5      �� -   5         ��Name$ menuList��5   L   $	��250��6   ���	#FF257CA9
�������$��0 50 0 0q�6�   .@�5      �� $��
10 10 0 10q�6   
 � Tag$
 Home��63   .��5      ��  �� Orientation$ 
Horizontal=�6!   $��Center=�6:   .+�5      �� $%��/Resources/Images/home_icon.png��6    $��20��6I   $��20��6T   �� 5      $��Trang chủ��6$   $#��/font/#Averta Std CY Semibold)�65   $��18(�6`   $��20 0 0 0q�6n   5      5      �� 5      $��
10 10 0 10q�6   $ Query��63   .��5      �� $ 
Horizontal=�6!   $��Center=�6:   .+�5      �� $'��!/Resources/Images/server_icon.png��6    $��20��6K   $��20��6V   �� 5      $��	Tra cứu��6$   $#��/font/#Averta Std CY Semibold)�63   $��18(�6^   $��20 0 0 0q�6l   5       5!      �� 5"      $��
10 10 0 10q�6   $ Profile��63   .��5#      �� $ 
Horizontal=�6!   $��Center=�6:   .+�5$      �� $%��/Resources/Images/user_icon.png��6    $��20��6I   $��20��6T   �� 5%      $
��Tôi��6$   $#��/font/#Averta Std CY Semibold)�6/   $��18(�6Z   $��20 0 0 0q�6h   5&      5'      �� 5(      $��
10 10 0 10q�6   $ Logout��63   .��5)      �� $ 
Horizontal=�6!   $��Center=�6:   .+�5*      �� $#��/Resources/Images/log_out.png��6    $��20��6G   $��20��6R   �� 5+      $��Đăng xuất��6$   $#��/font/#Averta Std CY Semibold)�65   $��18(�6`   $��20 0 0 0q�6n   5,      5-      5.      � 51      
�������$��
 0 50 0 0 q�6&   .+�52      �� -   5         ��Name$ content��52   !   53      54      �� 56   
   $ 
Horizontal=�6   
�������$	��Top=�6A   $��50��6Y   $��2��6e    J� Effect 57      3  -System.Windows.Media.Effects.DropShadowEffect  58         Color$ Black��6#   	   
BlurRadius$	 10Q�61   
   ShadowDepth$
 2Q�6A      Opacity$	 0.3Q�6Q   .+�5:      �� $[��UChào mừng bạn đến với hệ thống quản lý dịch bệnh và thiên tai!��6   $
��Bold"�6^   $��20(�6p   $��10q�6~   5;      5<      5=      